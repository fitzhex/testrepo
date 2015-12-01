package md51cf045d2d21743b7b2589fdd3eca9ac4;


public class Popup
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PI1M_Dashboard.T1.Droid.Popup, Sample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Popup.class, __md_methods);
	}


	public Popup () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Popup.class)
			mono.android.TypeManager.Activate ("PI1M_Dashboard.T1.Droid.Popup, Sample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
