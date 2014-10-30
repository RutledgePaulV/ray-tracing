using TracingGraphics.Utilities;

namespace TracingGraphics.Cameras
{
    public  class Camera
    {
        public Point3D Location;
        public Point3D FocalPoint;

        public Vector3D Up;
        public Vector3D XAxis, YAxis, ZAxis;

        public double RollAngle { get; set; }
        public double ExposureTime { get; set; }
        public double Zoom { get; set; }
        public double PlaneDistance { get; set; }

        public Camera()
        {
            Location = new Point3D(0,0,100);
            FocalPoint = new Point3D();
            RollAngle = 0;
            ExposureTime = 1;

            Up = new Vector3D(0,1,0);
            XAxis = new Vector3D(1,0,0);
            YAxis = new Vector3D(0,1,0);
            ZAxis = new Vector3D(0,0,1);
        }

        public Camera(Point3D _location, Point3D _focal_point, Vector3D _up, double plane_distance, double zoom)
        {
            Location = _location;
            FocalPoint = _focal_point;
            RollAngle = 0;
            ExposureTime = 1;
            PlaneDistance = plane_distance;
            Zoom = zoom;

            Up = _up;
            XAxis = new Vector3D(1, 0, 0);
            YAxis = new Vector3D(0, 1, 0);
            ZAxis = new Vector3D(0, 0, 1);
        }

        public void ComputeBasis()
        {
            var temp = Location.X == FocalPoint.X && Location.Z == FocalPoint.Z;

            if(temp && Location.Y > FocalPoint.Y)
            {
                ZAxis = new Vector3D(0,1,0);
                XAxis = new Vector3D(0,0,1);
                YAxis = new Vector3D(1,0,0);
            }
            else if(temp && Location.Y < FocalPoint.Y)
            {
                ZAxis = new Vector3D(0, -1, 0);
                XAxis = new Vector3D(1, 0, 0);
                YAxis = new Vector3D(0, 0, 1);
            }
            else
            {
                ZAxis = (Location-FocalPoint).Normalize();
                XAxis = (Up^ZAxis).Normalize();
                YAxis = (ZAxis ^ XAxis).Normalize();
            }

        }
    }
}
