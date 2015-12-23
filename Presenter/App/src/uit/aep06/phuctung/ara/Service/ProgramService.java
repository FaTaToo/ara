package uit.aep06.phuctung.ara.Service;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import uit.aep06.phuctung.ara.CommonClass.Program;
import uit.aep06.phuctung.ara.CommonClass.Mission;
import uit.aep06.phuctung.ara.CommonClass.MissionDefault;
import uit.aep06.phuctung.ara.CommonClass.MissionGPS;

public class ProgramService {
	public List<Program> getListProgram() {		
		List<Program> listProgram = new ArrayList<Program>();
		// fake data.
		listProgram.add(new Program(
				"1", 
				"Tên chương trình: Khuyến mãi Giáng sinh 2015",
				"Nhân dịp lễ Giáng sinh gần đến, Galaxy Cinema hân hạnh mang ưu đãi 'Giáng sinh ấm áp': Scan tìm hiểu thông tin 4 phim: 'Em là bà nội của anh', 'Hùng ALI', 'Kẻ săn bóng đêm', 'Đêm Giáng Sinh' để có thể được xem phim với giá ưu đãi. Giảm giá vé 10% cho mỗi bộ phim trên!", 
				"01/12/2015", 
				"25/12/2015", 
				"Galaxy Cinema", 1, 4, 1));
		listProgram.add(new Program(
				"1", 
				"Combo Spectre Giá Cực Sốc",
				"Nếu đang tiếc nuối vì đã lỡ mất đợt bán cùng phim vừa qua, đây là lúc để “rinh” Combo Spectre về nhà với giá vô cùng hấp dẫn chỉ 99.000VNĐ. Chỉ cần hoàn thành xong chiến dịch và bạn đã có thể thỏa mãn niềm mơ ước!", 
				"15/12/2015", 
				"17/12/2015", 
				"Galaxy Cinema", 0, 3, 0));
		listProgram.add(new Program(
				"1", 
				"Ưu Đãi Bất Ngờ Tại Galaxy Cinema",
				"Bắt đầu từ ngày 19/10 đến ngày 14/01/2016, sau khi hoàn thành chiến dịch này, nếu khách hàng mua vé xem phim tại Galaxy Cinema với giá trị thanh toán từ 100,000vnđ sẽ được tặng kèm 1 phần combo 1 gồm bắp & nước trị giá 61,000vnđ. Còn chờ gì nữa, hoàn thành chiến dịch và đến Galaxy xem phim ngay nhé!", 
				"19/10/2015", 
				"14/01/2016", 
				"Galaxy Cinema", 1, 2, 1));
		listProgram.add(new Program(
				"1", 
				"Giá Cực Sốc, Tăng Tốc Đến Trường",
				"Việc thưởng thức các bộ phim hay chưa bao giờ dễ dàng và thoải mái đến thế với các bạn sinh viên-học sinh, với chương trình ưu đãi giá vé hoàn toàn mới của Galaxy Cinema! Chỉ cần hoàn thành giá chiến dịch này, bạn sẽ có ngay cơ hội xem phim 2D với giá vé chỉ từ 40,000đ/vé", 
				"01/11/2015", 
				"31/12/2015", 
				"Galaxy Cinema", 0, 5, 3));
		
		return listProgram;
		
	}
	
	public List<Mission> getListMission(String id) throws JSONException {
		// implement code to get from service
		// fake 
		List<Mission> listMission = new ArrayList<Mission>();
		
		// ProgramID = 1
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
		target2.setName("Hùng ALI");
		target2.setState(1);
		target2.setYear("2015");
		target2.setDirector("Lâm Lê Dũng");
		target2.setActor("Ưng Hoàng Phúc , Hà Việt Dũng , Long Điền , Long Nhật");
		target2.setTargetContent("Scan poster của phim 'Hung ALI' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
		target2.setUrl("http://images.motthegioi.vn/uploaded/dieulinh/2015_11_15/hungali/ung-hoang-phuc-dang-qua-mao-hiem-cho-phim-hung-ali-hinh-anh-1.jpg?width=600");
		
		Mission target3 = new MissionDefault();
		target3.setType(1);
		target3.setName("Kẻ Săn Bóng Đêm - Keeper of Darkness");
		target3.setState(1);
		target3.setYear("2015");
		target3.setDirector(" Trương Gia Huy");
		target3.setActor("Trương Gia Huy, Quách Thái Khiết, Thích Hành Vũ");
		target3.setTargetContent("Scan poster của phim 'Kẻ săn bóng đêm' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
		target3.setUrl("https://chieuphimquocgia.com.vn/content/images/thumbs/0007508_ke-san-bong-dem-%282d-du-kien%29.jpg");
		
		Mission target4 = new MissionGPS();
		target4.setType(2);
		target4.setName("Đêm giáng sinh");
		target4.setYear("2015");
		target4.setDirector(" Trương Gia Huy");
		target4.setActor("Trương Gia Huy, Quách Thái Khiết, Thích Hành Vũ");
		target4.setTargetContent("Scan poster của phim 'Đêm giáng sinh' để nhận đc voucher giảm 10% giá vé. Nhanh tay lên nào mọi người ơi ^^");
		target4.setUrl("https://chieuphimquocgia.com.vn/content/images/thumbs/0007508_ke-san-bong-dem-%282d-du-kien%29.jpg");
		((MissionGPS)target4).setAddress("1 Cong Hoa; 54 Lu Gia; 246 Nguyen Chi Thanh; 47 Nguyen Hue");		
		
		listMission.add(target1);
		listMission.add(target2);
		listMission.add(target3);
		listMission.add(target4);
		
		return listMission; 
	}
}
