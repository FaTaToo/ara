package uit.aep06.phuctung.ara.VuforiaImplement.utils;

import javax.microedition.khronos.egl.EGLConfig;
import javax.microedition.khronos.opengles.GL10;

import android.opengl.GLES20;
import android.opengl.GLSurfaceView;
import android.opengl.Matrix;
import android.util.Log;
import uit.aep06.phuctung.ara.VuforiaImplement.ApplicationSession;

import com.qualcomm.vuforia.ImageTarget;
import com.qualcomm.vuforia.Matrix44F;
import com.qualcomm.vuforia.Renderer;
import com.qualcomm.vuforia.State;
import com.qualcomm.vuforia.Tool;
import com.qualcomm.vuforia.TrackableResult;
import com.qualcomm.vuforia.VIDEO_BACKGROUND_REFLECTION;
import com.qualcomm.vuforia.Vec2F;


//The renderer class for the CloudReco sample. 
public class MissionRenderer implements GLSurfaceView.Renderer
{
   ApplicationSession vuforiaAppSession;
   
   private static final float OBJECT_SCALE_FLOAT = 3.0f;
   
   
   
   public MissionRenderer(ApplicationSession session)
   {
       vuforiaAppSession = session;
   }
   
   
   // Called when the surface is created or recreated.
   @Override
   public void onSurfaceCreated(GL10 gl, EGLConfig config)
   {
       
       // Call Vuforia function to (re)initialize rendering after first use
       // or after OpenGL ES context was lost (e.g. after onPause/onResume):
       vuforiaAppSession.onSurfaceCreated();
   }
   
   
   // Called when the surface changed size.
   @Override
   public void onSurfaceChanged(GL10 gl, int width, int height)
   {
       // Call Vuforia function to handle render surface size changes:
       vuforiaAppSession.onSurfaceChanged(width, height);
   }
   
   
   // Called to draw the current frame.
   @Override
   public void onDrawFrame(GL10 gl)
   {
       // Call our function to render content
       renderFrame();
   }
   
   
   // The render function.
   private void renderFrame()
   {
       // Clear color and depth buffer
       GLES20.glClear(GLES20.GL_COLOR_BUFFER_BIT | GLES20.GL_DEPTH_BUFFER_BIT);
       
       // Get the state from Vuforia and mark the beginning of a rendering
       // section
       State state = Renderer.getInstance().begin();
       
       // Explicitly render the Video Background
       Renderer.getInstance().drawVideoBackground();
       
       GLES20.glEnable(GLES20.GL_DEPTH_TEST);
       GLES20.glEnable(GLES20.GL_CULL_FACE);
       if (Renderer.getInstance().getVideoBackgroundConfig().getReflection() == VIDEO_BACKGROUND_REFLECTION.VIDEO_BACKGROUND_REFLECTION_ON)
           GLES20.glFrontFace(GLES20.GL_CW);  // Front camera
       else
           GLES20.glFrontFace(GLES20.GL_CCW);   // Back camera
           
       // Did we find any trackables this frame?
       if (state.getNumTrackableResults() > 0)
       {
       	 Log.e("img", state.getNumTrackableResults() + " state num tracable");
           // Gets current trackable result
           TrackableResult trackableResult = state.getTrackableResult(0);
           
           if (trackableResult == null)
           {
               return;
           }
           
           
       }
       
       GLES20.glDisable(GLES20.GL_DEPTH_TEST);
       
       Renderer.getInstance().end();
   }
   
   
   private void renderAugmentation(TrackableResult trackableResult)
   {
   	/*ImageTarget  it = (ImageTarget)trackableResult.getTrackable();
   	Vec2F itSize = it.getSize();
   	
      Matrix44F modelViewMatrix_Vuforia = Tool
           .convertPose2GLMatrix(trackableResult.getPose());
       float[] modelViewMatrix = modelViewMatrix_Vuforia.getData();
       
       
       // deal with the modelview and projection matrices
       float[] modelViewProjection = new float[16];
       Matrix.translateM(modelViewMatrix, 0, 0.0f, 0.0f, OBJECT_SCALE_FLOAT);
       Matrix.scaleM(modelViewMatrix, 0, OBJECT_SCALE_FLOAT,
           OBJECT_SCALE_FLOAT, OBJECT_SCALE_FLOAT);
       Matrix.multiplyMM(modelViewProjection, 0, vuforiaAppSession
           .getProjectionMatrix().getData(), 0, modelViewMatrix, 0);
       */
   }
   
}

