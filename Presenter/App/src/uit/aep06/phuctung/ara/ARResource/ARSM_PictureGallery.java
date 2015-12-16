package uit.aep06.phuctung.ara.ARResource;

import java.util.ArrayList;
import java.util.List;



public class ARSM_PictureGallery extends ARSocialMediaResource {
	public  List<String> listUrl = new ArrayList<String>();
	public  List<String> getListUrl() {
		return listUrl;
	}

	public  void setListUrl(List<String> listUrl) {
		this.listUrl = listUrl;
	}
}
