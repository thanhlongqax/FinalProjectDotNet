// import icons
import {
  FaYoutube,
  FaFacebookF,
  FaInstagram,
  FaPinterestP,
  FaDiscord,
} from 'react-icons/fa';
// import images
import AboutImg from '../src/assets/img/about/plate.png';
import ModelWhiteImg from '../src/assets/img/model-white.png';
import ModelBlackImg from '../src/assets/img/model-black.png';
import MenuImg1 from '../src/assets/img/menu/1.png';
import MenuImg2 from '../src/assets/img/menu/2.png';
import MenuImg3 from '../src/assets/img/menu/3.png';
import MenuImg4 from '../src/assets/img/menu/4.png';
import SignatureImg from '../src/assets/img/team/signature.png';
import ChefImg from '../src/assets/img/team/chef.png';
import Avatar1 from '../src/assets/img/testimonial/avatar1.png';
import Avatar2 from '../src/assets/img/testimonial/avatar2.png';
import Avatar3 from '../src/assets/img/testimonial/avatar3.png';
import MenuListImg1 from '../src/assets/img/AnhMonAn/KimBak/truyen-thong.png';
import MenuListImg2 from '../src/assets/img/AnhMonAn/KimBak/chien-xu.png';
import MenuListImg3 from '../src/assets/img/AnhMonAn/KimBak/thit-heo.png';
import MenuListImg4 from '../src/assets/img/AnhMonAn/KimBak/trung-cuon.png';

export const navData = [
  { href: '/', name: 'home' },
  { href: '/', name: 'about us' },
  { href: '/', name: 'menu' },
  { href: '/', name: 'team' },
  { href: '/', name: 'book a table' },
  { href: '/', name: 'contact' },
];

export const heroData = {
  pretitle: 'Ẩm thực hàn quốc',
  title: 'Gimji',
  subtitle:
    'Mang tinh hoa chuẩn hàn đến với bạn ',
  btnText: 'Check me',
};

export const socialData = [
  { href: '/', icon: <FaYoutube /> },
  { href: '/', icon: <FaFacebookF /> },
  { href: '/', icon: <FaInstagram /> },
  { href: '/', icon: <FaPinterestP /> },
  { href: '/', icon: <FaDiscord /> },
];

export const aboutData = {
  pretitle: 'Câu chuyện của chúng tôi',
  title: 'Ẩm Thực Hàn Quốc Gimji',
  subtitle:
    'Nhắc đến xứ sở kim chi không thể không nhắc đến một nền ẩm thực phong phú, đa dạng, tinh tế. Món ăn Hàn Quốc dễ gây nghiện bởi không chỉ đẹp mắt mà hương vị cũng thật sự quyến rũ thực khách. Bằng niềm đam mê ẩm thực đậm tính văn hóa, Gimji tự hào mang đến cho thực khách một trải nghiệm chuẩn Hàn với những món ngon đặc trưng xứ kim chi. Thực đơn với nhiều món đa dạng, độc đáo được nghiên cứu, chắt lọc bởi công thức sốt bí truyền từ bếp trưởng Hàn Quốc với hơn 30 năm kinh nghiệm, sẽ làm hài lòng mọi thực khách khi đến với Gimji. Thực khách không chỉ thưởng thức trọn vẹn hương vị ẩm thực Hàn, mà còn nhận được sự phục vụ tận tình, chu đáo đầy tâm huyết từ Gimji.',
  btnText: 'find out more',
  image: AboutImg,
};

export const menuData = {
  title: 'Món Ăn Phong Phú Đa Dạng',
  subtitle: 'Toekbokki - Kimbab - Cơm Trộn - Bokkum - Salad - Thịt Nướng - Gà Sốt - Canh - Lẩu - Miến/Mì - Mì Cay - Phô mai kéo sợi',
  modelImg: ModelWhiteImg,
  btnText: 'Xem tất cả',
  menuItems: [
    {
      image: MenuImg1,
      name: 'Tokbokki gà',
      price: '69.000 đ',
      description: 'Bánh Gạo, Gà, Hành Tây, Cà rốt',
    },
    {
      image: MenuImg2,
      name: 'Cơm Trộn Hàn Quốc',
      price: '69,000 đ',
      description: 'Cơm, Thịt bò, Bí ngòi, Nấm đông cô, Cà rốt, Bó xôi, Giá HQ, Trứng',
    },
    {
      image: MenuImg3,
      name: 'Ba Chỉ Heo Nướng',
      price: '75,000 đ',
      description: 'Thịt heo, Sà lách, Lá mè, Dưa leo, Cà rốt, Tỏi, Ớt sừng xanh',
    },
    {
      image: MenuImg4,
      name: 'Gà Sốt Cay BBQ',
      price: '72,000 đ',
      description: 'Gà, Hành tây, Đậu Phộng, Mè, Salad mix',
    },
  ],
};

export const teamData = {
  pretitle: 'Đội ngũ đầu bếp của chúng tôi',
  title: '',
  sub1: ' Gimji đã quy tụ được đội ngũ đầu bếp có hơn 15 năm kinh nghiệm, chuyên nghiệp trong lĩnh vực ẩm thực, từng làm rất nhiều món ăn hàn quốc nên thấu hiểu rõ khẩu vị của thực khách để có thể mang lại những món ăn hấp dẫn.',
  sub2: 'Những người đầu bếp của Gimji luôn biết cách kết hợp nguyên liệu, gia vị, dụng cụ và những sáng tạo trong phong cách thưởng thức để làm mới thực đơn có thể đem lại sự thích thú cũng như tò mò, kích thích vị giác cho thực khách.',
  name: 'sara peter',
  occupation: 'Bếp trưởng',
  signatureImg: SignatureImg,
  chefImg: ChefImg,
};

export const testimonialData = {
  title: "what client's say ",
  subtitle: '1500+ statisfied clients',
  modelImg: ModelWhiteImg,
  slider: [
    {
      message:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio quas ipsum eius voluptatibus. Quod ipsum ullam id facere a beatae incidunt eaque, veritatis architecto cum perferendis debitis tempora.',
      image: Avatar1,
      name: 'Rick Thompson',
      occupation: 'CEO of Delightful',
    },
    {
      message:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio quas ipsum eius voluptatibus. Quod ipsum ullam id facere a beatae incidunt eaque, veritatis architecto cum perferendis debitis tempora.',
      image: Avatar2,
      name: 'John Doe',
      occupation: 'CEO of Delightful',
    },
    {
      message:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio quas ipsum eius voluptatibus. Quod ipsum ullam id facere a beatae incidunt eaque, veritatis architecto cum perferendis debitis tempora.',
      image: Avatar3,
      name: 'Henry A.',
      occupation: 'CEO of Delightful',
    },
  ],
};

export const reservationData = {
  title: 'Đặt bàn',
  subtitle:
    'Liên hệ (+84)866-001-283 từ 8AM - 9PM hàng ngày, hoặc đặt bàn online.',
  modelImg: ModelBlackImg,
  btnText: 'Đặt bàn',
};

export const newsletterData = {
  title: 'Theo dõi chúng tôi',
  subtitle: 'Nhận tin tức và cập nhật mới nhất.',
  placeholder: 'gmail',
  btnText: 'Đăng ký ngay',
};

export const footerData = {
  contact: {
    title: 'Liên Hệ',
    address: '40A Phạm Văn Xảo, P. Phú Thọ Hòa, Q. Tân Phú, TP. HCM',
    phone: '(+84)866-001-283',
  },
  hours: {
    title: 'Giờ mở cửa',
    program: [
      {
        days: 'T2 - T6',
        hours: '09:00 AM - 10:00 PM',
      },
      {
        days: 'T7 - CN',
        hours: '09:00 AM - 11:00 PM',
      },
    ],
  },
  social: {
    title: 'Kênh thông tin',
    icons: [
      { href: '/', icon: <FaYoutube /> },
      { href: '/', icon: <FaFacebookF /> },
      { href: '/', icon: <FaInstagram /> },
      { href: '/', icon: <FaPinterestP /> },
      { href: '/', icon: <FaDiscord /> },
    ],
  },
};