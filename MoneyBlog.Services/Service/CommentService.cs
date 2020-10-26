﻿using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;

namespace MoneyBlog.Services.Service
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Comment Create(int articleId, string userId, string email, string body)
        {
            Comment comment = new Comment()
            {
                ArticleId = articleId,
                UserId = userId,
                Email = email,
                Body = body,
                CreatedOn = DateTime.Now
            };
            _commentRepository.Create(comment);
            return comment;
        }
        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }
        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }
        public List<Comment> GetAllArticle(int articleId)
        {
            return _commentRepository.GetAllArticle(articleId);
        }
    }
}
