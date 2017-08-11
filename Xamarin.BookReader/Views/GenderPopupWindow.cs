﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.BookReader.Bases;
using Xamarin.BookReader.Managers;

namespace Xamarin.BookReader.Views
{
    public class GenderPopupWindow : PopupWindow
    {
        private View mContentView;
        private Activity mActivity;

        private Button mBtnMale;
        private Button mBtnFemale;
        private ImageView mIvClose;

        public GenderPopupWindow(Activity activity)
        {
            mActivity = activity;
            Width = (ViewGroup.LayoutParams.MatchParent);
            Height = (ViewGroup.LayoutParams.WrapContent);

            mContentView = LayoutInflater.From(activity).Inflate(Resource.Layout.layout_gender_popup_window, null);
            ContentView = (mContentView);
            Focusable = (true);
            OutsideTouchable = (true);
            Touchable = (true);
            SetBackgroundDrawable(new ColorDrawable(Color.ParseColor("#00000000")));

            AnimationStyle = (Resource.Style.LoginPopup);

            DismissEvent += (sender, e) =>
            {
                lighton();
                // TODO: EventBus.getDefault().post(new UserSexChooseFinishedEvent());
            };

            mBtnMale = (Button)mContentView.FindViewById(Resource.Id.mBtnMale);

            mBtnMale.Click += (sender, e) =>
            {
                // TODO: SettingManager.getInstance().saveUserChooseSex(Constant.Gender.Male);
                Dismiss();
            };

            mBtnFemale = (Button)mContentView.FindViewById(Resource.Id.mBtnFemale);
            mBtnFemale.Click += (sender, e) =>
            {
                // TODO: SettingManager.getInstance().saveUserChooseSex(Constant.Gender.Female);
                Dismiss();
            };

            mIvClose = (ImageView)mContentView.FindViewById(Resource.Id.mIvClose);
            mIvClose.Click += (sender, e) =>
            {
                Dismiss();
            };
        }

        private void lighton()
        {
            WindowManagerLayoutParams lp = mActivity.Window.Attributes;
            lp.Alpha = 1.0f;
            mActivity.Window.Attributes = (lp);
        }

        private void lightoff()
        {
            WindowManagerLayoutParams lp = mActivity.Window.Attributes;
            lp.Alpha = 0.3f;
            mActivity.Window.Attributes = (lp);
        }

        public override void ShowAsDropDown(View anchor, int xoff, int yoff)
        {
            lightoff();
            base.ShowAsDropDown(anchor, xoff, yoff);
        }

        public override void ShowAtLocation(View parent, GravityFlags gravity, int x, int y)
        {
            lightoff();
            base.ShowAtLocation(parent, gravity, x, y);
        }
    }
}