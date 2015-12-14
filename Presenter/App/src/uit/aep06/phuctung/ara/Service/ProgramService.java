package uit.aep06.phuctung.ara.Service;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import uit.aep06.phuctung.ara.CommonClass.Target;
import uit.aep06.phuctung.ara.CommonClass.TargetDefault;

public class ProgramService {
	public List<Target> getListTarget(String id) throws JSONException {
		// implement code to get from service
		// fake 
		List<Target> listTarget = new ArrayList<Target>();
		
		Target target1 = new TargetDefault();
		target1.setName("Target 1");
		target1.setYear("2015");
		target1.setDirector("Pham Tang Tung");
		target1.setActor("Pham Dinh Thinh");
		target1.setTargetContent("This is target content");
		target1.setUrl("http://icons.iconarchive.com/icons/designbolts/rio-2-movie/512/Rio2-Family-icon.png");
		
		Target target2 = new TargetDefault();
		target2.setName("Target 2");
		target2.setYear("2015");
		target2.setDirector("Le Sanh Phuc");
		target2.setActor("Le Dinh Thinh");
		target2.setTargetContent("This is target content 2");
		target2.setUrl("http://icons.iconarchive.com/icons/designbolts/rio-2-movie/512/Rio2-Family-icon.png");
		listTarget.add(target1);
		listTarget.add(target2);
		
		return listTarget; 
	}
}
