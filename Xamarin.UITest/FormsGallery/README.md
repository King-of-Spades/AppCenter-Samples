# Build Status Badge
Android: [![Build status](https://build.appcenter.ms/v0.1/apps/67b70b47-a923-4864-bc05-170020d0eefe/branches/master/badge)](https://appcenter.ms)
iOS Simulator: [![Build status](https://build.appcenter.ms/v0.1/apps/a32536d6-a435-4895-9874-50a9282d3336/branches/master/badge)](https://appcenter.ms)


FormsGallery Xamarin.UITest sample
============

This sample displays all the views, cells, layouts, and pages available in Xamarin.Forms, one per page; and some basic Xamarin.UITest interactions with those elements. 

- Original sample based on: https://github.com/xamarin/xamarin-forms-samples/tree/master/FormsGallery
- Some inspiration and implementation ideas from: https://github.com/michael-watson/forms-xtc-guide (The readme contains code examples very similar to this project, but those eamples are not actually implmented into the project code.)

# General Xamarin.UITest project structure
## AppInitializer
This is a fairly standard format for enabling cross-platform Android & iOS testing. It's essentially using the default Visual Studio Mac template for a cross-platform UITest, except for line 35:

>  Environment.SetEnvironmentVariable("UITEST_FORCE_IOS_SIM_RESTART", "1");

This environment variable is used so that when testing on a local iOS simulator, the app is always restarted. This is required to work around a local testing bug in the current stable version of Xamarin.UITest (at the time of writing this). 

## Multiple Test Fixtures
Each of these .cs files is a separate Test Fixture, which are named based on the grouped related elements in the underlying Xamarin.Forms app navigation:
- Cells.cs
- LayoutsWithMultipleChildren.cs
- LayoutsWithSingleContent.cs
- Pages.cs
- ViewsForEditingText.cs
- ViewsForPresentation.cs
- ViewsForSettingValues.cs
- ViewsThatDisplayCollections.cs
- ViewsThatInitiateCommands.cs

## HelperMethods.cs
This file contains methods which are shared across each and every Test Fixture listed above, to handle common shared logic and/or especially complex testing scenarios. 

#### TestFixture required SetUp method
This includes a required [SetUp] method called "BeforeEachTest()", which is executed _before each [Test]_:
https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/FormsGallery/FormsGallery.UITest/HelperMethods.cs#L100-L104

#### OpenPage(string page, int pageType)
- *page* - pass a case-sensitive string for Xamarin.UITest to find on the main page of the app. UITest will tap the element to open the page or scroll down on the view if it's not found to see if it appears and then can tap it. 
- *pageType* - Selects either "C# Pages" or "XAML Pages" in the UI before finding the specific page searched for.

Source: https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/FormsGallery/FormsGallery.UITest/HelperMethods.cs#L14-L31

#### SetDatePicker(DateTime date)
This method Invokes native Android & iOS methods on their respective platforms in order to update the DatePicker values.

- *date* - Takes a standard "DateTime" value, though the method only works with Month, Day & Year; because those are what the Forms DatePickers are set up to work with. 

Source: https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/FormsGallery/FormsGallery.UITest/HelperMethods.cs#L34-L57

Called by **ViewsforSettingValues.cs -> [Test] DatePicker()**: https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/FormsGallery/FormsGallery.UITest/ViewsForSettingValues.cs#L81-L93

#### SetTimePicker (int hour, int minute, bool am)
Unlike `SetDatePicker` this method can't directly accept a DateTime, because it would require setting a day, month, & year when only the hour, minute & am/pm values are actually needed. This is worked around by using DateTime.Now within the method itself so that it can be handled in a somewhat similar fashion to the companion `SetDatePicker` method.

- Source: https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/FormsGallery/FormsGallery.UITest/HelperMethods.cs#L59-L98

Called by **ViewsforSettingValues.cs -> [Test] TimePicker()**: https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/FormsGallery/FormsGallery.UITest/ViewsForSettingValues.cs#L95-L107
