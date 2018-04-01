# WPFWndProcHookSample

<pre><code>// Binding to 'Loaded' Event in window
private void loadedForm(object sender, RoutedEventArgs e)
{
    HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
     source.AddHook(new HwndSourceHook(WndProc));
}</code></pre>
