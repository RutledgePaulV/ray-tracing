using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TracingGraphics.Cameras;
using TracingGraphics.Global;
using TracingGraphics.Lights;
using TracingGraphics.Materials;
using TracingGraphics.Renderables;
using TracingGraphics.Renderers;
using TracingGraphics.Samplers;
using TracingGraphics.Utilities;

namespace RayTracer
{
    public partial class MainWindow : Window
    {
        public WriteableBitmap Canvas;
        public int MyWidth = 580;
        public int MyHeight = 580;
        public double Offset = 40;
        public double Radius = 20;

        public MainWindow()
        {
            InitializeComponent();
            Canvas = new WriteableBitmap(MyWidth,MyHeight,72,72,PixelFormats.Bgra32,null);
            ImageHolder.Source = Canvas;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
          
            ////////////////////////////
            /* CONSTRUCTING THE SCENE */
            ////////////////////////////
            var ambient = new Ambient();
            var background = new RGBColor(0.2f);
       
            var lights = new ConcurrentBag<Light> {new PointLight(new Point3D(200,200,1000)){Intensity = 4}};
            var objects = new ConcurrentBag<GeometricObject>();

            var material1 = new Matte {Ka = 0.01, Kd=0.99, Cd = new RGBColor(0.5,0,0.5)};
            var material2 = new Matte {Ka = 0.3, Kd = 0.7, Cd = new RGBColor(0.1,0.1,0.1)};

            var sphere1 = new Sphere(new Point3D(-Offset, 0, 0), Radius) {Material = material1};
            var sphere2 = new Sphere(new Point3D(Offset, 0, 0), Radius) {Material = material1};
            var sphere3 = new Sphere(new Point3D(0, Offset, 0), Radius) {Material = material2};
            var sphere4 = new Sphere(new Point3D(0, -Offset, 0), Radius) {Material = material2};

            objects.Add(sphere1);
            objects.Add(sphere2);
            objects.Add(sphere3);
            objects.Add(sphere4);

            var scene = new Scene(background, ambient, lights, objects);
            ///////////////////////////////
            /* END CONSTRUCTION OF SCENE */
            ///////////////////////////////

            
            Sampler sampler = new Jittered(64,87);
            var render = new Renderer(ref Canvas, ref sampler);
            var view_plane = new ViewPlane(MyWidth,MyHeight, 1);
            var camera = new Camera(new Point3D(0,0,120), new Point3D(0,0,0),new Vector3D(0,1,0),120,2);
            camera.ComputeBasis();
            
            render.Render(ref scene, ref view_plane, ref camera);

        }



    }
}
