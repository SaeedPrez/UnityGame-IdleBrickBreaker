﻿using System.Collections;
using DG.Tweening;
using Prez.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Prez
{
    [SelectionBase]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _baseSpeed;
        [SerializeField] private float _movementLimitToX;
        [SerializeField] private float _movementLimitFromX;
        [SerializeField] private float _velocityMultiplierX;
        [SerializeField] private float _playerIdleTime;
        [SerializeField] private SpriteRenderer _bgImage;
        [SerializeField] private SpriteRenderer _borderImage;
        [SerializeField] private Transform _cooldownIndicator;
        [SerializeField, Range(0f, 1f)] private float _idleAlpha;

        private EventManager _event;
        private Rigidbody2D _rigidbody;
        private CapsuleCollider2D _collider;
        private Vector2 _playerInput;
        private bool _isPlayerActive;
        private float _playerIdleCooldown;

        private void Awake()
        {
            _event = EventManager.I;
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CapsuleCollider2D>();
        }

        private void OnEnable()
        {
            _event.OnPlayerInputMove += OnPlayerInputMove;
            SetPlayerActive();
            StartCoroutine(SetPlayerIdle());
        }

        private void OnDisable()
        {
            _event.OnPlayerInputMove -= OnPlayerInputMove;
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void OnPlayerInputMove(Vector2 input)
        {
            _playerInput = new Vector2(input.x, 0);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Ball"))
                return;

            var collisionPoint = transform.InverseTransformPoint(other.GetContact(0).point);
            var ball = other.gameObject.GetComponent<Ball>();
            ball.ChangeVelocityX(collisionPoint.x * _velocityMultiplierX);
        }

        /// <summary>
        /// Moves the player.
        /// </summary>
        private void MovePlayer()
        {
            if (_playerInput.x == 0f)
                return;
            
            var x = _rigidbody.position.x + _playerInput.x * (_baseSpeed * Time.fixedDeltaTime);
            x = Mathf.Clamp(x, _movementLimitToX, _movementLimitFromX);
            
            _rigidbody.MovePosition(new Vector2(x, transform.position.y));
            SetPlayerActive();
        }

        /// <summary>
        /// Sets the player to active state.
        /// </summary>
        private void SetPlayerActive()
        {
            _playerIdleCooldown = _playerIdleTime;
            
            if (_isPlayerActive)
                return;
            
            _isPlayerActive = true;
            _collider.enabled = true;

            _bgImage.DOKill();
            _borderImage.DOKill();
            
            _bgImage.DOFade(1, 0.1f);
            _borderImage.DOFade(1, 0.1f);
        }

        /// <summary>
        /// Sets the player to idle state.
        /// </summary>
        /// <returns></returns>
        private IEnumerator SetPlayerIdle()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.25f);

                if (!_isPlayerActive)
                    continue;

                _playerIdleCooldown -= 0.25f;
                var percent = _playerIdleCooldown / _playerIdleTime;
                _borderImage.DOFade(percent, 0.1f);

                _cooldownIndicator.DOKill();
                _cooldownIndicator.DOScaleX(percent, 0.1f);
                
                if (_playerIdleCooldown > 0f)
                    continue;

                _isPlayerActive = false;
                _collider.enabled = false;
                _bgImage.DOKill();
                _bgImage.DOFade(_idleAlpha, 0.25f);
            }
        }
    }
}