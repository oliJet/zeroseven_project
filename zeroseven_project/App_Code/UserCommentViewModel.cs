using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace zeroseven_project.App_Code.Models
{
    public class UserCommentModel
    {
        [Required, Display(Name = "Commenter")]
        public string Commenter { get; set; }

        [Required, Display(Name = "CommentContent")]
        public string CommentContent { get; set; }
        public Umbraco.Core.Udi CharacterNodeId { get; set; }

    }
}