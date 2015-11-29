// --------------------------------------------------------------------------------------------------------------------
/* <header file="AraVwsCaller.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement Client for emptying Vuforia Cloud database.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace VwsCaller
{
    /// <summary>
    /// Delete all targets in  Vuforia Cloud database.
    /// </summary>
    public class AraVwsCaller
    {
        #region SMethods
        /// <summary>
        /// Main method of AraVwsCaller
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var callPostNewTarget = new WebClient();
            using (var sr = File.OpenText(@"D:\Projects\ARA\1.0\src-manager\Manager\ARAManager\ARAManager.Presentation\ARAManager.Presentation.Client\Ara_Data\Targets\ListTargets.txt"))
            {
                string target;
                while ((target = sr.ReadLine()) != null)
                {
                    callPostNewTarget.DownloadString(new Uri(
                   "http://localhost:1234/ara-vws/vws/SampleSelector.php?select=DeleteTarget&targetId=" + target));
                }
            }

            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"D:\Projects\ARA\1.0\src-manager\Tools\Snapshots\src\EmptyArData.bat",
                    WorkingDirectory = @"D:\Projects\ARA\1.0\src-manager\Tools\Snapshots\src"
                }
            };
            process.Start();
        }
        #endregion SMethods
    }
}
