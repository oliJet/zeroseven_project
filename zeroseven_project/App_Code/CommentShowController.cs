using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace zeroseven_project.App_Code
{
    public class CommentShowController : SurfaceController
    {
        [ChildActionOnly]
        public ActionResult _CommentSectionPartialView()
        {

            GuidUdi currentPageUdi = new GuidUdi(CurrentPage.ContentType.ItemType.ToString(), CurrentPage.Key);
            //IPublishedContent selection = Umbraco.Content(currentPageUdi)
            //.ChildrenOfType("characterComment")
            //.Where(x => x.IsVisible());
            return PartialView();
        }
    }
}