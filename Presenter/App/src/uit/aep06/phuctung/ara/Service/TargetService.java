package uit.aep06.phuctung.ara.Service;

public class TargetService { //need to extends service
	public String GetDataTarget(String targetID) {
		//Implement code to get string result from Service later
		//Now, fake data
		String result = "<ARResources><ARResource><ARType>ARSM-PicturesGallery</ARType><CommonAttributes><Attribute><Key>URL</Key><Value>http://www.filmhdwallpapers.com/files/movies/Rio%202%20HD%20Wallpapers.jpg</Value><Extras /></Attribute><Attribute><Key>URL</Key><Value>https://tancap.in/wallpaper/9/3/hd-movie-2-2014.jpg</Value><Extras /></Attribute><Attribute><Key>URL</Key><Value>http://www.hdwallpaperscool.com/wp-content/uploads/2014/04/rio2-movie-hd-wallpapers.jpg</Value><Extras /></Attribute><Attribute><Key>URL</Key><Value>http://cinemasiren.com/wp-content/uploads/2014/04/rio-2.jpg</Value><Extras /></Attribute></CommonAttributes><SpecialAttributes /><Tags /><Platforms><Platform><PlatformID>Android</PlatformID><Processors><Processor><ProcessorType>ImageSwitcher</ProcessorType><Data /></Processor></Processors></Platform></Platforms></ARResource><ARResource><ARType>ARSM-Youtube</ARType><CommonAttributes><Attribute><Key>URL</Key><Value>https://www.youtube.com/watch?v=81ll2B4zl1g</Value><Extras /></Attribute></CommonAttributes><SpecialAttributes /><Tags /><Platforms><Platform><PlatformID>Android</PlatformID><Processors><Processor><ProcessorType>Youtube</ProcessorType><Data /></Processor></Processors></Platform></Platforms></ARResource><ARResource><ARType>ARSM-Facebook</ARType><CommonAttributes><Attribute><Key>URL</Key><Value>http://www.imdb.com/title/tt1253863/?ref_=nv_sr_1</Value><Extras /></Attribute></CommonAttributes><SpecialAttributes /><Tags /><Platforms><Platform><PlatformID>Android</PlatformID><Processors><Processor><ProcessorType>Facebook</ProcessorType><Data /></Processor></Processors></Platform></Platforms></ARResource><ARResource><ARType>ARMM-Text</ARType><CommonAttributes><Attribute><Key>Name</Key><Value>Rise of an empire</Value></Attribute><Attribute><Key>Director</Key><Value>Noam Murro</Value></Attribute><Attribute><Key>Actor</Key><Value>2014</Value></Attribute><Attribute><Key>Description</Key><Value>Blu, Jewel and their three kids living the perfect domesticated life in the magical city that is Rio de Janeiro. When Jewel decides the kids need to learn to live like real birds, she insists the family venture into the Amazon. As Blu tries to fit in with his new neighbors, he worries he may lose Jewel and the kids to the call of the wild.</Value><Extras /></Attribute></CommonAttributes><SpecialAttributes /><Tags /><Platforms><Platform><PlatformID>Android</PlatformID><Processors><Processor><ProcessorType>TextView</ProcessorType><Data /></Processor></Processors></Platform></Platforms></ARResource></ARResources>";
		return result;
	}
	
	public int checkTargetState(String id, String userID) {
		return 0;
	}

}
