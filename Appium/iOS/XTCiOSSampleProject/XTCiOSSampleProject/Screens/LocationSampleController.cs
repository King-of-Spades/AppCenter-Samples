using System;
using CoreLocation;
using UIKit;
using System.Threading.Tasks;

namespace XTCiOSSampleProject
{
    public class XTCLocationManager : CLLocationManager
    {
        public async override void RequestWhenInUseAuthorization()
        {
            await Task.Run(() => Task.Delay(TimeSpan.FromSeconds(1)));

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                base.RequestWhenInUseAuthorization();
            }

            base.StartUpdatingLocation();
        }
    }

	public partial class LocationSampleController : UIViewController
	{
        public LocationSampleController () : base ("LocationSampleController", null)
		{
			Title = "LocationSampleController";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

            latLabel.AccessibilityIdentifier = "latLabel";
            lonLabel.AccessibilityIdentifier = "lonLabel";

            var locationManager = new XTCLocationManager();

            Task.Run(() => locationManager.RequestWhenInUseAuthorization());

            locationManager.AuthorizationChanged += (object s, CLAuthorizationChangedEventArgs e) =>
            {
                Console.WriteLine("Authorization changed to: {0}", e.Status);

                if (locationManager.Location == null)
                    Console.WriteLine("location is null");
                else
                {
                    var location = locationManager.Location;
                    latLabel.Text = location.Coordinate.Latitude.ToString();
                    lonLabel.Text = location.Coordinate.Longitude.ToString();
                }

                if (e.Status == CLAuthorizationStatus.AuthorizedWhenInUse ||
                    e.Status == CLAuthorizationStatus.AuthorizedAlways)
                {
                    locationEnabledLabel.Text = "Authorized"; 
                }
            };

            locationManager.LocationsUpdated += (object s, CLLocationsUpdatedEventArgs e) =>
            {
                var location = e.Locations[e.Locations.Length - 1];
                latLabel.Text = location.Coordinate.Latitude.ToString();
                lonLabel.Text = location.Coordinate.Longitude.ToString();
            };
		}
	}
}
