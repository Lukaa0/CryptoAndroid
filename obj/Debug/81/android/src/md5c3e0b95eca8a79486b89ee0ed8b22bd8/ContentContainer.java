package md5c3e0b95eca8a79486b89ee0ed8b22bd8;


public class ContentContainer
	extends md5c3e0b95eca8a79486b89ee0ed8b22bd8.SfSwipePager
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Syncfusion.Android.TabView.ContentContainer, Syncfusion.SfTabView.Android", ContentContainer.class, __md_methods);
	}


	public ContentContainer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ContentContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.TabView.ContentContainer, Syncfusion.SfTabView.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ContentContainer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ContentContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.TabView.ContentContainer, Syncfusion.SfTabView.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ContentContainer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ContentContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.TabView.ContentContainer, Syncfusion.SfTabView.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ContentContainer (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ContentContainer.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.TabView.ContentContainer, Syncfusion.SfTabView.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
