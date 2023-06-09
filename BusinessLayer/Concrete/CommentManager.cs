﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentSevice
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public void AddComment(Comment comment)
        {
            
            _commentdal.Insert(comment);
        }

        public List<Comment> GetList(int id)
        {
            return _commentdal.GetAll(x => x.BlogID == id);
        }
    }
}
