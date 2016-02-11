package uit.aep06.phuctung.ara.Service;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.client.ClientProtocolException;
import org.json.JSONException;

import uit.aep06.phuctung.ara.CommonClass.Comment;

public class CommentService {
	public void addNewComment(Comment comment) throws JSONException, ClientProtocolException, IOException{
		
	}
	
	public List<Comment> getAllComments(String targetID) throws JSONException {
		//fake data
		List<Comment> listComments = new ArrayList<Comment>();		
		
		Comment comment1 = new Comment();		
		comment1.rating = 5;
		comment1.fullName =
				"Vo Thanh Tam";
		comment1.customerID = 1;
		comment1.customerComment = "Five stars!";
		
		Comment comment2 = new Comment();		
		comment2.rating = 4;
		comment2.fullName = "Tran Thai Hoa";
		comment2.customerID = 2;
		comment2.customerComment = "OK";
		
		listComments.add(comment1);
		listComments.add(comment2);
		return listComments;
	}
}
