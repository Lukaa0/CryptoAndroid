package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();
				java.io.File external0 = android.os.Environment.getExternalStorageDirectory ();
				String externalDir = new java.io.File (
							external0,
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();
				String externalLegacyDir = new java.io.File (
							external0,
							"../legacy/Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new String[] {
							externalDir,
							externalLegacyDir
						},
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "HC.dll" comes first in this list. */
		"HC.dll",
		"AFollestad.MaterialDialogs.Core.dll",
		"BottomNavigationBar.dll",
		"crypto.dll",
		"CryptoCompare.dll",
		"Firebase.Xamarin.dll",
		"FloatingActionButton-Xamarin.dll",
		"FloatingNavigationView.dll",
		"FormsViewGroup.dll",
		"Glide.dll",
		"JazzyViewPager.dll",
		"JWT.dll",
		"LguipengBubbleView.dll",
		"MaterialDateTimePicker.dll",
		"MaterialSearchView.dll",
		"Mjn1369PrettyDialog.dll",
		"Naxam.DialogPlus.Droid.dll",
		"Newtonsoft.Json.dll",
		"Plugin.Connectivity.Abstractions.dll",
		"Plugin.Connectivity.dll",
		"PortableCryptoLibrary.dll",
		"PortableCryptoServices.dll",
		"RecyclerViewAnimators.dll",
		"Refractored.Controls.CircleImageView.dll",
		"Refractored.PagerSlidingTabStrip.dll",
		"SkiaSharp.dll",
		"SkiaSharp.Views.Android.dll",
		"SQLite-net.dll",
		"SQLite.Net.Async.dll",
		"SQLite.Net.dll",
		"SQLitePCLRaw.batteries_green.dll",
		"SQLitePCLRaw.batteries_v2.dll",
		"SQLitePCLRaw.core.dll",
		"SQLitePCLRaw.lib.e_sqlite3.dll",
		"SQLitePCLRaw.provider.e_sqlite3.dll",
		"Square.OkHttp.dll",
		"Square.OkIO.dll",
		"Square.Picasso.dll",
		"Syncfusion.Buttons.Android.dll",
		"Syncfusion.Core.XForms.Android.dll",
		"Syncfusion.Core.XForms.dll",
		"Syncfusion.Licensing.dll",
		"Syncfusion.SfBusyIndicator.Android.dll",
		"Syncfusion.SfChart.Android.dll",
		"Syncfusion.SfProgressBar.XForms.Android.dll",
		"Syncfusion.SfProgressBar.XForms.dll",
		"Syncfusion.SfTabView.Android.dll",
		"System.Data.SQLite.dll",
		"System.Reactive.Core.dll",
		"System.Reactive.Interfaces.dll",
		"System.Reactive.Linq.dll",
		"System.Reactive.PlatformServices.dll",
		"Xamarin.Android.Arch.Core.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.Runtime.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.Annotations.dll",
		"Xamarin.Android.Support.Compat.dll",
		"Xamarin.Android.Support.Constraint.Layout.dll",
		"Xamarin.Android.Support.Constraint.Layout.Solver.dll",
		"Xamarin.Android.Support.Core.UI.dll",
		"Xamarin.Android.Support.Core.Utils.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.Fragment.dll",
		"Xamarin.Android.Support.Media.Compat.dll",
		"Xamarin.Android.Support.Transition.dll",
		"Xamarin.Android.Support.v13.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Android.Support.v7.Palette.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.Firebase.Analytics.dll",
		"Xamarin.Firebase.Analytics.Impl.dll",
		"Xamarin.Firebase.Auth.dll",
		"Xamarin.Firebase.Common.dll",
		"Xamarin.Firebase.Database.Connection.dll",
		"Xamarin.Firebase.Database.dll",
		"Xamarin.Firebase.Iid.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Xamarin.GooglePlayServices.Base.dll",
		"Xamarin.GooglePlayServices.Basement.dll",
		"Xamarin.GooglePlayServices.Tasks.dll",
		"ZhangHai.Android.MaterialProgressBar.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_27";
}