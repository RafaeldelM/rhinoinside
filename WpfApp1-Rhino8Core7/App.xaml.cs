using Rhino.Geometry;
using Rhino.Runtime.InProcess;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp1_Rhino8Core7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            // Inicializa Rhino Inside
            RhinoInside.Resolver.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            System.IO.Directory.SetCurrentDirectory(RhinoInside.Resolver.RhinoSystemDirectory);

            using (new RhinoCore())
            {
                var sphere = new Sphere(Point3d.Origin, 12);
                var brep = sphere.ToBrep();
                var mp = new MeshingParameters(0.5);
                var mesh = Mesh.CreateFromBrep(brep, mp);
                /*Console.WriteLine($"Mesh with {mesh[0].Vertices.Count} vertices created");
                Console.WriteLine("press any key to exit");
                Console.ReadKey();*/
            }
         



        }
    }

}
