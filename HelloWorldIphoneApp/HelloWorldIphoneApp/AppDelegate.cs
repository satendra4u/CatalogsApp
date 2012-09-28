using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Util;
using System.Web.Services;


namespace HelloWorldIphoneApp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public UIWindow window;
		public UINavigationController _navController;
		public DialogViewController _rootViewController;
		public RootElement _rootElement;
		public List<UIImage> myImages;
		public RectangleF _bounds;
		public UIImageView myAnimatedView; 
		FileInfo f;



		public NSUrl ns = new NSUrl("http://www.littelfuse.com/about-us/~/media/Files/Littelfuse/Technical%20Resources/Documents/Product%20Catalogs/Content/OE101.pdf");
	


		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size



			window = new UIWindow (UIScreen.MainScreen.Bounds);

			myImages = new List<UIImage> ();


			myImages.Add (UIImage.FromFile ("Images/Icon-72.png"));
			myImages.Add (UIImage.FromFile ("Images/Icon.png"));
			myImages.Add (UIImage.FromFile ("Images/Icon-72.png"));
			
			myImages.Add (UIImage.FromFile ("Images/Icon-72.png"));


			_bounds = new RectangleF (140, 140, 140, 140);

			myAnimatedView = new UIImageView (_bounds);

			myAnimatedView.AnimationImages = myImages.ToArray();


			if (myImages.Count > 0) {
			
				Console.WriteLine (myImages.Count);
		
				myAnimatedView.AnimationDuration = 6.75; // Seconds
				
				myAnimatedView.AnimationRepeatCount = 0; // 0 = Loops 

				myAnimatedView.StartAnimating();

			}



			_rootViewController = new DialogViewController(new RootElement("Littelfuse") {
					
					new Section(""){},
					new Section (myAnimatedView){},
					

					JsonElement.FromFile("element.json")
				
					/*new Section ("Catalogs") {
						new RootElement ("Electronics") {
							new Section () {
								new HtmlElement("Electronics 1",ns),
								new HtmlElement("Electronics 2",ns),
								new HtmlElement("Electronics 3",ns),
								new HtmlElement("Electronics 4",ns),
								new HtmlElement("Electronics 5",ns),
								new HtmlElement("Electronics 6",ns),
								new HtmlElement("Electronics 7",ns),
								new HtmlElement("Electronics 8",ns),
								new HtmlElement("Electronics 9",ns),
								new HtmlElement("Electronics 10",ns)
							}
							
						},
						new RootElement("Electrical")
						{
							new Section () {
								
								new HtmlElement("Electrical 1",ns),
								new HtmlElement("Electrical 2",ns),
								new HtmlElement("Electrical 3",ns),
								new HtmlElement("Electrical 4",ns),
								new HtmlElement("Electrical 5",ns),
								new HtmlElement("Electrical 6",ns),
								new HtmlElement("Electrical 7",ns),
								new HtmlElement("Electrical 8",ns),
								new HtmlElement("Electrical 9",ns),
								new HtmlElement("Electrical 10",ns)
									
							}
							
						}

					}*/
					
				}
		);

			_navController = new UINavigationController(_rootViewController);

			 window.RootViewController = _navController;
		

			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
		
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}


	}
}

