package uit.aep06.phuctung.ara.Service;

import java.util.ArrayList;
import java.util.List;

import org.json.JSONException;

import uit.aep06.phuctung.ara.CommonClass.Program;
import uit.aep06.phuctung.ara.CommonClass.Target;
import uit.aep06.phuctung.ara.CommonClass.TargetDefault;

public class ProgramService {
	public List<Program> getListProgram() {		
		List<Program> listProgram = new ArrayList<Program>();
		// fake data.
		listProgram.add(new Program(
				"1", 
				"Tên chương trình: Khuyến mãi Giáng sinh 2015",
				"Nhân dịp lễ Giáng sinh gần đến, Galaxy Cinema hân hạnh mang ưu đãi 'Giáng sinh ấm áp': Scan tìm hiểu thông tin 4 phim: 'Em là bà nội của anh', 'Hùng ALI', 'Kẻ săn bóng đêm', 'Đêm Giáng Sinh' để có thể được xem phim với giá ưu đãi. Giảm giá vé 20% cho một trong bốn bộ phim trên!", 
				"01/12/2015", 
				"25/12/2015", 
				"Galaxy Cinema", 1, 3, 1));
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
