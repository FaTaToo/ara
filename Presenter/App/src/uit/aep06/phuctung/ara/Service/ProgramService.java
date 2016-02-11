package uit.aep06.phuctung.ara.Service;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import android.support.v4.widget.ListViewAutoScrollHelper;
import uit.aep06.phuctung.ara.CommonClass.Program;
import uit.aep06.phuctung.ara.CommonClass.Mission;
import uit.aep06.phuctung.ara.CommonClass.MissionDefault;
import uit.aep06.phuctung.ara.CommonClass.MissionGPS;

public class ProgramService {
	public List<Program> getListProgram() {		
		List<Program> listProgram = new ArrayList<Program>();
		// fake data.
		
		listProgram.add(new Program(
				"11", 
				"Giá Cực Sốc, Tăng Tốc Đến Trường",
				"Việc thưởng thức các bộ phim hay chưa bao giờ dễ dàng và thoải mái đến thế với các bạn sinh viên-học sinh, với chương trình ưu đãi giá vé hoàn toàn mới của Galaxy Cinema! Chỉ cần hoàn thành giá chiến dịch này, bạn sẽ có ngay cơ hội xem phim 2D với giá vé chỉ từ 40,000đ/vé", 
				"01/11/2015", 
				"31/12/2015", 
				"Galaxy Cinema",1, 0, 1, 1));
		listProgram.add(new Program(
				"1", 
				" Xem phim đầu xuân",
				"Nhân dịp năm mơi, Galaxy hân hạnh mang ưu đãi 'Đón xuân an lành': Hãy chech-in phim 'Diếp Vấn 3' tại Galaxy An Dương Vương hoặc Galaxy Tân Bình để có thể được xem phim với giá ưu đãi. Giảm giá vé 10% cho mỗi phim trên tại các rạp Galaxy trên địa bàn thành phố!", 
				"01/01/2015", 
				"31/01/2015", 
				"Galaxy An Dương Vương", 0, 0, 1, 0));
				
		listProgram.add(new Program(
				"2", 
				"Combo Spectre Special",
				"Happy New Year Every one! Big time is comming! Complete this campaign to get Combo Spectre with special price!!! Once more time, happy new year every one. Wish best for all of you!!!", 
				"05/01/2015", 
				"10/01/2015", 
				"Galaxy Cinema", 1, 2, 1, 1));
		listProgram.add(new Program(
				"12", 
				"Ưu Đãi Bất Ngờ Tại Galaxy Cinema",
				"Bắt đầu từ ngày 19/10 đến ngày 14/01/2016, sau khi hoàn thành chiến dịch này, nếu khách hàng mua vé xem phim tại Galaxy Cinema với giá trị thanh toán từ 100,000vnđ sẽ được tặng kèm 1 phần combo 1 gồm bắp & nước trị giá 61,000vnđ. Còn chờ gì nữa, hoàn thành chiến dịch và đến Galaxy xem phim ngay nhé!", 
				"19/10/2015", 
				"14/01/2016", 
				"Galaxy Cinema",1, 2, 1, 1));
		listProgram.add(new Program(
				"3", 
				"Giá Cực Sốc, Tăng Tốc Đến Trường",
				"Việc thưởng thức các bộ phim hay chưa bao giờ dễ dàng và thoải mái đến thế với các bạn sinh viên-học sinh, với chương trình ưu đãi giá vé hoàn toàn mới của Galaxy Cinema! Chỉ cần hoàn thành giá chiến dịch này, bạn sẽ có ngay cơ hội xem phim 2D với giá vé chỉ từ 40,000đ/vé", 
				"01/01/2015", 
				"10/01/2015", 
				"Galaxy Cinema",0, 1, 3, 0));
		
		return listProgram;
		
	}
	
	public List<Mission> getListMission(String id) throws JSONException {
		// implement code to get from service
		// fake 
		List<Mission> listMission = new ArrayList<Mission>();
		try {
			Thread.sleep(3000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		if (id.equals("1")) {
			Mission target1 = new MissionGPS();
			target1.setType(1);
			target1.setName("Diệp Vấn 3");
			target1.setState(0);
			target1.setYear("2016");
			target1.setDirector("Diệp Vỹ Tín");
			target1.setActor("Chân Tử Đan; Hùng Đại Lâm");
			target1.setTargetContent("Phần 3 của loạt phim Diệp Vấn mang tên DIỆP VẤN 3, cũng chính là tác phẩm cuối cùng khép lại loạt phim kinh điển này. Trong phần này, bộ phim khắc họa tình cảm thầy trò của giữa Diệp Vấn và Lý Tiểu Long, bên cạnh đó phim sẽ khai thác cuộc đối đầu khốc liệt của Diệp Vấn và vị võ sĩ quyền Anh người Mỹ. ");
			target1.setUrl("https://i.moveek.com/media/2015/12/400x600-cYehD35W01.jpg");
			listMission.add(target1);
			((MissionGPS)target1).setAddress("126 Tản Đà; 6 Nguyễn Hồng Đào;");
			return listMission;
		}
		if (id.equals("2")){
			Mission target1 = new MissionDefault();
			target1.setType(1);
			target1.setName("The road trip");
			target1.setState(0);
			target1.setYear("2016");
			target1.setDirector("Walt Beckker");
			target1.setActor("Bella Thome; Kaley Cuoco; Anna Faris");
			target1.setTargetContent("Ba chú sóc chuột vui nhộn Alvin, Simon và Theodore sẽ tái ngộ khán giả trong phần 4 có tên Alvin And The Chipmunks: The Road Trip. Ở phần này, cho rằng ông chủ Dave sẽ cầu hôn bạn gái và bỏ rơi mình, ba chú sóc quyết định tìm cách để khiến anh bỏ đi ý định đó. Tuy nhiên, nhiệm vụ đầu tiên là phải tìm ra Dave ở thành phố Miami xinh đẹp.");
			target1.setUrl("https://www.galaxycine.vn/media/a/l/alvin-ngang.jpg");
			listMission.add(target1);			
			return listMission;
		}
		if (id.equals("3")) {
			Mission target1 = new MissionDefault();
			target1.setType(1);
			target1.setName("Em là bà nội của anh");
			target1.setState(1);
			target1.setYear("2015");
			target1.setDirector("Phan Gia Nhật Linh");
			target1.setActor("Miu Lê; Ngô Kiến Huy; Hứa Vĩ Văn; Hari Won");
			target1.setTargetContent("Scan poster của phim 'Em là bà nội của anh' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
			target1.setUrl("http://c1.f9.img.vnecdn.net/2015/10/07/mgG0ozOdmjvkFqKDjUC-JcZm43rWCS-4487-2619-1444194762.jpg");
						
			Mission target2 = new MissionDefault();
			target2.setType(1);
			target2.setName("Bố ngoan bố hư");
			target2.setState(1);
			target2.setYear("2015");
			target2.setDirector("Sean Ander");
			target2.setActor("Tome; Max");
			target2.setTargetContent("Chuyện phim hứa hẹn mang lại nhiều tiếng cười sảng khoái tới khán giả cùng người thân qua những tình huống éo le nhưng cũng rất thực tế, được đúc kết từ chính trải nghiệm của tác giả kịch bản Brian Burns. BỐ NGOAN, BỐ HƯ là cuộc chiến vô cùng đáng yêu khi anh chồng Dusty (Mark Wahlberg) với lối sống phóng túng, cực kỳ ngông cuồng, trở về để xen vào cuộc sống của vợ cũ khi hay tin nàng vừa tái hôn.");
			target2.setUrl("http://phimchieurap.vn/wp-content/uploads/2015/12/Bo-Ngoan-Bo-Hu-Poster_2-360x540.jpg");
			
			Mission target3 = new MissionDefault();
			target3.setType(1);
			target3.setName("Tây Du Kí kiếp nạn 82");
			target3.setState(1);
			target3.setYear("2015");
			target3.setDirector(" Trương Gia Huy");
			target3.setActor("Trương Gia Huy, Quách Thái Khiết, Thích Hành Vũ");
			target3.setTargetContent("Scan poster của phim 'Kẻ săn bóng đêm' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
			target3.setUrl("http://hanoimoi.com.vn/Uploads/image/News/Thumbnails/2012/11/Thumbnails305420120354051.jpg");
			
			listMission.add(target1);
			listMission.add(target2);
			listMission.add(target3);
			return listMission;
		}
		// ProgramID = 1
		
		
		
		Mission target2 = new MissionDefault();
		target2.setType(1);
		target2.setName("Bố ngoan bố hư");
		target2.setState(1);
		target2.setYear("2015");
		target2.setDirector("Sean Ander");
		target2.setActor("Tome; Max");
		target2.setTargetContent("Chuyện phim hứa hẹn mang lại nhiều tiếng cười sảng khoái tới khán giả cùng người thân qua những tình huống éo le nhưng cũng rất thực tế, được đúc kết từ chính trải nghiệm của tác giả kịch bản Brian Burns. BỐ NGOAN, BỐ HƯ là cuộc chiến vô cùng đáng yêu khi anh chồng Dusty (Mark Wahlberg) với lối sống phóng túng, cực kỳ ngông cuồng, trở về để xen vào cuộc sống của vợ cũ khi hay tin nàng vừa tái hôn.");
		target2.setUrl("http://phimchieurap.vn/wp-content/uploads/2015/12/Bo-Ngoan-Bo-Hu-Poster_2-360x540.jpg");
		
		Mission target3 = new MissionDefault();
		target3.setType(1);
		target3.setName("Kẻ Săn Bóng Đêm - Keeper of Darkness");
		target3.setState(1);
		target3.setYear("2015");
		target3.setDirector(" Trương Gia Huy");
		target3.setActor("Trương Gia Huy, Quách Thái Khiết, Thích Hành Vũ");
		target3.setTargetContent("Scan poster của phim 'Kẻ săn bóng đêm' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
		target3.setUrl("http://phimchieurap.vn/wp-content/uploads/2015/12/Bo-Ngoan-Bo-Hu-Poster_2-360x540.jpg");
		
		Mission target4 = new MissionGPS();
		target4.setType(2);
		target4.setName("Đêm giáng sinh");
		target4.setYear("2015");
		target4.setDirector(" Trương Gia Huy");
		target4.setActor("Trương Gia Huy, Quách Thái Khiết, Thích Hành Vũ");
		target4.setTargetContent("Scan poster của phim 'Đêm giáng sinh' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
		target4.setUrl("https://chieuphimquocgia.com.vn/content/images/thumbs/0007508_ke-san-bong-dem-%282d-du-kien%29.jpg");
		((MissionGPS)target4).setAddress("1 Cong Hoa; 54 Lu Gia; 246 Nguyen Chi Thanh; 47 Nguyen Hue");		
		
		
		listMission.add(target2);
		listMission.add(target3);
		listMission.add(target4);
		
		return listMission; 
	}
}
