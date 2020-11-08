# MessageBoxPositionManager

A small library that moves all newly created MessageBoxes to the center of their owner forms.

<p align="center">
  <img src="https://repository-images.githubusercontent.com/310921599/dc308600-21ef-11eb-8a35-4a18f3b97094" width=800/>
</p>

Works well with both the `System.Windows.MessageBox` (WPF) and the `System.Windows.Forms.MessageBox` (WindowsForms).

To set it up simply install the package (`dotnet add package MessageBoxPositionManager`) and call the following static method from your UI thread (once, during the startup of your app):

```csharp
MessageBoxCenteringService.Initialize();
```

Later on, you can simply use the `MessageBox.Show` method to display new modals. No additional code is required to move the windows around.

If a MessageBox is attached to an owner, it will be rendered in a center of that window.

```csharp
MessageBox.Show(this, "Some content", "Title");
```

If a MessageBox is displayed without an owner, it will be rendered in a center of the currently active window or the center of the screen if no window is currently active.

```csharp
MessageBox.Show("Some content", "Title");
```

The package was create based on the ideas collected from [this StackOveflow thread](https://stackoverflow.com/questions/1732443/center-messagebox-in-parent-form).
