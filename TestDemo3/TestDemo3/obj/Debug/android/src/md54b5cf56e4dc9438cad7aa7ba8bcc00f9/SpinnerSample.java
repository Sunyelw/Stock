package md54b5cf56e4dc9438cad7aa7ba8bcc00f9;


public class SpinnerSample
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TestDemo3.SpinnerSample, TestDemo3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SpinnerSample.class, __md_methods);
	}


	public SpinnerSample () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SpinnerSample.class)
			mono.android.TypeManager.Activate ("TestDemo3.SpinnerSample, TestDemo3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
