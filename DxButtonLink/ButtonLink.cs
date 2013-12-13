using System;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

namespace DXX
{
    [DefaultProperty("Text")]
    [ToolboxData(@"<{0}:ButtonLink runat=""server"" Text=""Displays a button that navigates like a hyperlink."" EncodeHtml=""false"" />")]
    [ToolboxBitmap(typeof(ASPxButton))]
    [SupportsEventValidation]
    public class ButtonLink : ASPxButton
    {
        #region ASPxHyperlink members

        /// <summary>
        /// REQUIRED unless ClientSideEvents.Click is used
        /// </summary>
        [DefaultValue("")]
        [Localizable(false)]
        [Bindable(true)]
        public string NavigateUrl { get; set; }

        #endregion

        [Obsolete("Replace with NavigateUrl for HTTP GET rather cross-page post back.", error: true)]
        public new string PostBackUrl {
            get { return null; }
            set { throw new Exception("Do not use PostBackUrl."); }
        }

        [Obsolete("AutoPostBack is always false.", error: true)]
        public new bool AutoPostBack
        {
            get { return false; }
            set { throw new Exception("Do not use AutoPostBack."); }
        }

        [Obsolete("CausesValidation is always false.", error: true)]
        public new bool CausesValidation
        {
            get { return false; }
            set { throw new Exception("Do not use CausesValidation."); }
        }

        [Obsolete("UseSubmitBehavior is always false.", error: true)]
        public new bool UseSubmitBehavior
        {
            get { return false; }
            set { throw new Exception("Do not use UseSubmitBehavior."); }
        }

        [Obsolete("Server-side Click, Command and CheckedChanged events are not supported.", error: true)]
        [Category("Action")]
        public new event EventHandler CheckedChanged;
        [Obsolete("Server-side Click, Command and CheckedChanged events are not supported.", error: true)]
        [Category("Action")]
        public new event EventHandler Click;
        [Obsolete("Server-side Click, Command and CheckedChanged events are not supported.", error: true)]
        [Category("Action")]
        public new event CommandEventHandler Command;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            base.AutoPostBack = false;
            base.CausesValidation = false;
            base.UseSubmitBehavior = false;
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (!Visible) return;

            if (base.AutoPostBack)
            {
                throw new ArgumentException("AutoPostBack cannot be true.");
            }

            if (base.CausesValidation)
            {
                throw new ArgumentException("CausesValidation cannot be true.");
            }

            if (base.UseSubmitBehavior)
            {
                throw new ArgumentException("UseSubmitBehavior cannot be true.");
            }

            if (!String.IsNullOrWhiteSpace(base.PostBackUrl))
            {
                throw new ArgumentException("PostBackUrl cannot have a value.");
            }

            if (this.Click != null || this.Command != null || this.CheckedChanged != null)
            {
                throw new ArgumentException("Server-side Click, Command and CheckedChanged events are not supported.");
            }

            bool hasNavUrl = !String.IsNullOrWhiteSpace(NavigateUrl);
            bool hasClientClick = !String.IsNullOrWhiteSpace(ClientSideEvents.Click);

            if (!hasNavUrl && !hasClientClick)
            {
                throw new ArgumentException("NavigateUrl or ClientSideEvents.Click is required.");
            }
            else if (hasNavUrl && hasClientClick)
            {
                throw new ArgumentException("Use either NavigateUrl or ClientSideEvents.Click.");
            }

            if (hasNavUrl)
            {
                string js = "function(s,e) { window.location.href = " + HttpUtility.JavaScriptStringEncode(NavigateUrl, true) + "; e.processOnServer = false; }";

                ClientSideEvents.Click = js;
            }

            base.RenderControl(writer);
        }
    }
}
