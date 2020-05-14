using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Services.Implement;
using Umbraco.Core.Services;
using Umbraco.Web.Models;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using zeroseven_project.App_Code.Models;

namespace zeroseven_project
{

    public class CharacterCommentSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {


        [HttpPost]
        [ActionName("PostCharacterComment")]
        public ActionResult PostCharacterComment(UserCommentModel Model)
        {

            GuidUdi currentPageUdi = new GuidUdi(CurrentPage.ContentType.ItemType.ToString(), CurrentPage.Key);
            
            Umbraco.Core.Udi parentId = currentPageUdi;

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            CreateComment(Model.Commenter, Model.CommentContent, parentId);
            return CurrentUmbracoPage();
        }

        private void CreateComment(string commenter, string comment, Umbraco.Core.Udi parentId)
        {
            IContentService contentService = Services.ContentService;
            var content = contentService.CreateContent(DateTime.Today.ToString("yy/MM/dd h:mm tt"), parentId, "characterComment");
            int id = CurrentPage.Id;
            content.SetValue("commenter", commenter);
            content.SetValue("commentContent", comment);
            content.SetValue("charicterParentId", id);
            contentService.SaveAndPublish(content);

        }
    }
}