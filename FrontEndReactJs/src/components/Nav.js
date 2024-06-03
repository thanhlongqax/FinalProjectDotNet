import React from 'react';
import { Link } from 'react-router-dom';

const Nav = () => {
  return (
    <nav className='w-full h-full'>
      <ul className='h-full flex flex-col justify-center items-center gap-y-6'>
        <li className='text-xl capitalize font-primary italic hover:text-dark transition-all duration-300'>
          <Link to="/Gimji">Trang chủ</Link>
        </li>
        <li className='text-xl capitalize font-primary italic hover:text-dark transition-all duration-300'>
          <Link to="/ve-chung-toi">Câu chuyện của chúng tôi</Link>
        </li>
        <li className='text-xl capitalize font-primary italic hover:text-dark transition-all duration-300'>
          <Link to="/thuc-don">Thực đơn</Link>
        </li>
        <li className='text-xl capitalize font-primary italic hover:text-dark transition-all duration-300'>
          <Link to="/doi-ngu-dau-bep">Đội ngũ đầu bếp</Link>
        </li>
        <li className='text-xl capitalize font-primary italic hover:text-dark transition-all duration-300'>
          <Link to="/dat-ban">Đặt bàn</Link>
        </li>
        <li className='text-xl capitalize font-primary italic hover:text-dark transition-all duration-300'>
          <Link to="/lien-he">Liên hệ</Link>
        </li>
      </ul>
    </nav>

  );
};

export default Nav;
