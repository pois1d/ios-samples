using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;

namespace PaintCode
{
	// http://mikebluestein.wordpress.com/2010/02/21/drawing-with-coregraphics-in-monotouch-2/
	public class DrawingView : UIView
	{
		public DrawingView ()
		{
			BackgroundColor = UIColor.White;
		}

		public DrawingView (IntPtr p) : base(p)
		{
			BackgroundColor = UIColor.White;
		}
			
		public override void Draw (RectangleF rect)
		{
			base.Draw (rect);

			// ------------- START PAINTCODE ----------------
			
			
			//// General Declarations
			var colorSpace = CGColorSpace.CreateDeviceRGB ();
			var context = UIGraphics.GetCurrentContext ();

//// Color Declarations
			UIColor gold = UIColor.FromRGBA (1.00f, 0.95f, 0.57f, 1.00f);
			UIColor brown = UIColor.FromRGBA (0.79f, 0.75f, 0.18f, 1.00f);
			UIColor lightBrown = UIColor.FromRGBA (0.69f, 0.57f, 0.23f, 1.00f);
			UIColor darkishBlue = UIColor.FromRGBA (0.20f, 0.39f, 0.98f, 1.00f);
			UIColor bottomColorDown = UIColor.FromRGBA (0.21f, 0.21f, 0.21f, 1.00f);

//// Gradient Declarations
			var newGradientColors = new CGColor [] {UIColor.Black.CGColor, UIColor.White.CGColor};
			var newGradientLocations = new float [] {0, 1};
			var newGradient = new CGGradient (colorSpace, newGradientColors, newGradientLocations);
			var calendarGradientColors = new CGColor [] {
				UIColor.DarkGray.CGColor,
				UIColor.FromRGBA (0.72f, 0.72f, 0.72f, 1.00f).CGColor,
				UIColor.White.CGColor
			};
			var calendarGradientLocations = new float [] {0, 0.26f, 0.26f};
			var calendarGradient = new CGGradient (colorSpace, calendarGradientColors, calendarGradientLocations);

//// Shadow Declarations
			var shadow = UIColor.DarkGray.CGColor;
			var shadowOffset = new SizeF (2, 2);
			var shadowBlurRadius = 2;

//// Abstracted Graphic Attributes
			var monthContent = "MAR";
			var dayContent = "24";
			var dayFont = UIFont.FromName ("Helvetica-Bold", 24);
			var textContent = "News Headline";


//// Oval 11 Drawing
			var oval11Path = UIBezierPath.FromOval (new RectangleF (256.5f, 46.5f, 13, 14));
			lightBrown.SetFill ();
			oval11Path.Fill ();

			UIColor.Black.SetStroke ();
			oval11Path.LineWidth = 1;
			oval11Path.Stroke ();


//// Oval 12 Drawing
			var oval12Path = UIBezierPath.FromOval (new RectangleF (280.5f, 46.5f, 13, 14));
			lightBrown.SetFill ();
			oval12Path.Fill ();

			UIColor.Black.SetStroke ();
			oval12Path.LineWidth = 1;
			oval12Path.Stroke ();


//// Rounded Rectangle Drawing
			var roundedRectanglePath = UIBezierPath.FromRoundedRect (new RectangleF (8.5f, 60.5f, 37, 36), 4);
			context.SaveState ();
			context.SetShadowWithColor (shadowOffset, shadowBlurRadius, shadow);
			context.BeginTransparencyLayer (null);
			roundedRectanglePath.AddClip ();
			context.DrawLinearGradient (calendarGradient, new PointF (27, 96.5f), new PointF (27, 60.5f), 0);
			context.EndTransparencyLayer ();
			context.RestoreState ();

			UIColor.DarkGray.SetStroke ();
			roundedRectanglePath.LineWidth = 1;
			roundedRectanglePath.Stroke ();


//// Rounded Rectangle 3 Drawing
			UIBezierPath roundedRectangle3Path = new UIBezierPath ();
			roundedRectangle3Path.MoveTo (new PointF (9, 91.2f));
			roundedRectangle3Path.AddCurveToPoint (new PointF (12.56f, 95), new PointF (9, 93.3f), new PointF (10.32f, 95));
			roundedRectangle3Path.AddLineTo (new PointF (40.94f, 95));
			roundedRectangle3Path.AddCurveToPoint (new PointF (45, 91.2f), new PointF (43.18f, 95), new PointF (45, 93.3f));
			roundedRectangle3Path.AddLineTo (new PointF (45, 87));
			roundedRectangle3Path.AddCurveToPoint (new PointF (43.42f, 85.5f), new PointF (45, 84.9f), new PointF (45.66f, 85.5f));
			roundedRectangle3Path.AddLineTo (new PointF (10.94f, 85.5f));
			roundedRectangle3Path.AddCurveToPoint (new PointF (9, 87), new PointF (8.7f, 85.5f), new PointF (9, 84.9f));
			roundedRectangle3Path.AddLineTo (new PointF (9, 91.2f));
			roundedRectangle3Path.ClosePath ();
			UIColor.Red.SetFill ();
			roundedRectangle3Path.Fill ();



//// Month Drawing
			var monthRect = new RectangleF (10, 84, 34, 15);
			UIColor.White.SetFill ();
			new NSString (monthContent).DrawString (
				monthRect,
				UIFont.FromName("Helvetica-Bold", 9),
				UILineBreakMode.WordWrap,
				UITextAlignment.Center
			);


//// Day Drawing
			var dayRect = new RectangleF (0, 58, 54, 31);
			UIColor.Black.SetFill ();
			new NSString (dayContent).DrawString (dayRect, dayFont, UILineBreakMode.WordWrap, UITextAlignment.Center);


//// Text Drawing
			var textRect = new RectangleF (54, 60, 75, 38);
			UIColor.Black.SetFill ();
			new NSString (textContent).DrawString (
				textRect,
				UIFont.FromName("Helvetica", 16),
				UILineBreakMode.WordWrap,
				UITextAlignment.Left
			);


//// Star Drawing
			UIBezierPath starPath = new UIBezierPath ();
			starPath.MoveTo (new PointF (31, 14.5f));
			starPath.AddLineTo (new PointF (26.24f, 21.45f));
			starPath.AddLineTo (new PointF (18.16f, 23.83f));
			starPath.AddLineTo (new PointF (23.3f, 30.5f));
			starPath.AddLineTo (new PointF (23.06f, 38.92f));
			starPath.AddLineTo (new PointF (31, 36.1f));
			starPath.AddLineTo (new PointF (38.94f, 38.92f));
			starPath.AddLineTo (new PointF (38.7f, 30.5f));
			starPath.AddLineTo (new PointF (43.84f, 23.83f));
			starPath.AddLineTo (new PointF (35.76f, 21.45f));
			starPath.ClosePath ();
			gold.SetFill ();
			starPath.Fill ();

			brown.SetStroke ();
			starPath.LineWidth = 1;
			starPath.Stroke ();


//// Blue blob Drawing
			UIBezierPath blueBlobPath = new UIBezierPath ();
			blueBlobPath.MoveTo (new PointF (256.5f, 16.5f));
			blueBlobPath.AddCurveToPoint (new PointF (240.5f, 41.5f), new PointF (235.5f, 37.5f), new PointF (217.53f, 41.55f));
			blueBlobPath.AddCurveToPoint (new PointF (265.5f, 30.5f), new PointF (263.47f, 41.45f), new PointF (265.5f, 30.5f));
			blueBlobPath.AddCurveToPoint (new PointF (256.5f, 16.5f), new PointF (265.5f, 30.5f), new PointF (277.5f, -4.5f));
			blueBlobPath.ClosePath ();
			blueBlobPath.MiterLimit = 2;
			blueBlobPath.LineJoinStyle = CGLineJoin.Round;
			darkishBlue.SetFill ();
			blueBlobPath.Fill ();

			bottomColorDown.SetStroke ();
			blueBlobPath.LineWidth = 1;
			blueBlobPath.Stroke ();


//// Button Drawing
			var buttonPath = UIBezierPath.FromRoundedRect (new RectangleF (54.5f, 10.5f, 163, 31), 4);
			context.SaveState ();
			buttonPath.AddClip ();
			context.DrawRadialGradient (newGradient,
    new PointF (100.39f, 55.13f), 7.84f,
    new PointF (136, 26), 86.67f,
    CGGradientDrawingOptions.DrawsBeforeStartLocation | CGGradientDrawingOptions.DrawsAfterEndLocation);
			context.RestoreState ();

			UIColor.Black.SetStroke ();
			buttonPath.LineWidth = 1;
			buttonPath.Stroke ();


//// Smiley face Drawing
			var smileyFacePath = UIBezierPath.FromOval (new RectangleF (159.5f, 49.5f, 47, 47));
			gold.SetFill ();
			smileyFacePath.Fill ();

			UIColor.Black.SetStroke ();
			smileyFacePath.LineWidth = 1;
			smileyFacePath.Stroke ();


//// Oval 2 Drawing
			var oval2Path = UIBezierPath.FromOval (new RectangleF (169.5f, 64.5f, 8, 8));
			UIColor.Black.SetFill ();
			oval2Path.Fill ();

			UIColor.Black.SetStroke ();
			oval2Path.LineWidth = 1;
			oval2Path.Stroke ();


//// Oval 3 Drawing
			var oval3Path = UIBezierPath.FromOval (new RectangleF (188.5f, 64.5f, 8, 8));
			UIColor.Black.SetFill ();
			oval3Path.Fill ();

			UIColor.Black.SetStroke ();
			oval3Path.LineWidth = 1;
			oval3Path.Stroke ();


//// Bezier 2 Drawing
			UIBezierPath bezier2Path = new UIBezierPath ();
			bezier2Path.MoveTo (new PointF (172.5f, 80.5f));
			bezier2Path.AddCurveToPoint (new PointF (185.5f, 85.5f), new PointF (177.75f, 85), new PointF (182.04f, 86.03f));
			bezier2Path.AddCurveToPoint (new PointF (194.5f, 79.5f), new PointF (191.27f, 84.62f), new PointF (194.5f, 79.5f));
			UIColor.Black.SetStroke ();
			bezier2Path.LineWidth = 2;
			bezier2Path.Stroke ();


//// Oval 5 Drawing
			var oval5Path = UIBezierPath.FromOval (new RectangleF (256.5f, 52.5f, 36, 33));
			lightBrown.SetFill ();
			oval5Path.Fill ();

			UIColor.Black.SetStroke ();
			oval5Path.LineWidth = 1;
			oval5Path.Stroke ();


//// Oval 6 Drawing
			var oval6Path = UIBezierPath.FromOval (new RectangleF (262.5f, 59.5f, 10, 19));
			UIColor.White.SetFill ();
			oval6Path.Fill ();

			UIColor.Black.SetStroke ();
			oval6Path.LineWidth = 1;
			oval6Path.Stroke ();


//// Oval 7 Drawing
			var oval7Path = UIBezierPath.FromOval (new RectangleF (275.5f, 59.5f, 10, 19));
			UIColor.White.SetFill ();
			oval7Path.Fill ();

			UIColor.Black.SetStroke ();
			oval7Path.LineWidth = 1;
			oval7Path.Stroke ();


//// Oval 9 Drawing
			var oval9Path = UIBezierPath.FromOval (new RectangleF (264.5f, 68.5f, 6, 5));
			UIColor.Black.SetFill ();
			oval9Path.Fill ();

			UIColor.Black.SetStroke ();
			oval9Path.LineWidth = 1;
			oval9Path.Stroke ();


//// Oval 10 Drawing
			var oval10Path = UIBezierPath.FromOval (new RectangleF (277.5f, 68.5f, 6, 5));
			UIColor.Black.SetFill ();
			oval10Path.Fill ();

			UIColor.Black.SetStroke ();
			oval10Path.LineWidth = 1;
			oval10Path.Stroke ();


//// Oval 4 Drawing
			var oval4Path = UIBezierPath.FromOval (new RectangleF (250.5f, 70.5f, 47, 24));
			lightBrown.SetFill ();
			oval4Path.Fill ();

			UIColor.Black.SetStroke ();
			oval4Path.LineWidth = 1;
			oval4Path.Stroke ();


//// Oval 8 Drawing
			var oval8Path = UIBezierPath.FromOval (new RectangleF (267.5f, 77.5f, 9, 4));
			UIColor.Black.SetFill ();
			oval8Path.Fill ();

			UIColor.Black.SetStroke ();
			oval8Path.LineWidth = 1;
			oval8Path.Stroke ();


//// Bezier 5 Drawing
			UIBezierPath bezier5Path = new UIBezierPath ();
			bezier5Path.MoveTo (new PointF (270.5f, 81.5f));
			bezier5Path.AddCurveToPoint (new PointF (267.5f, 88.5f), new PointF (269.5f, 85.5f), new PointF (267.5f, 88.5f));
			UIColor.Black.SetStroke ();
			bezier5Path.LineWidth = 1;
			bezier5Path.Stroke ();


//// Bezier 6 Drawing
			UIBezierPath bezier6Path = new UIBezierPath ();
			bezier6Path.MoveTo (new PointF (272.5f, 81.5f));
			bezier6Path.AddLineTo (new PointF (274.5f, 87.5f));
			UIColor.Black.SetStroke ();
			bezier6Path.LineWidth = 1;
			bezier6Path.Stroke ();








			
			
			
			// ------------- END PAINTCODE ----------------
		}
	}
}

