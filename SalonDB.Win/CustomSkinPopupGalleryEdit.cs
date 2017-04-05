using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Win
{
    public class CustomSkinPopupGalleryEdit : PopupGalleryEdit
    {
        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new CustomPopupGalleryForm(this);
        }
    }
    public class CustomPopupGalleryForm : PopupGalleryForm
    {
        public CustomPopupGalleryForm(DevExpress.XtraEditors.PopupBaseEdit ownerEdit)
            : base(ownerEdit)
        {
        }
        public override void ShowPopupForm()
        {
            InitSkinGallery();
            base.ShowPopupForm();
        }
        private void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(GalleryControl);
        }

        public override System.Drawing.Size CalcFormSize(System.Drawing.Size contentSize)
        {
            //return base.CalcFormSize();
            System.Drawing.Size newSize = new System.Drawing.Size(500, 400);
            return newSize;
        }

    }
}
