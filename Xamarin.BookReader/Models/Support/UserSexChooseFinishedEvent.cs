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
using DSoft.Messaging;

namespace Xamarin.BookReader.Models.Support
{
    public class UserSexChooseFinishedEvent : MessageBusEvent
    {
        public override string EventId => "UserSexChooseFinishedEvent";
    }
}