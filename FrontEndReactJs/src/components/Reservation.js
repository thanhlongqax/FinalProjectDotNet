import React, { useState } from 'react';
import { reservationData } from '../data';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import TimePicker from 'react-time-picker';
import '../assets/css/timepicker.css';
import { FaUsers, FaCalendar, FaClock } from 'react-icons/fa';
import { fadeIn, staggerContainer } from '../animation/variants';


const Reservation = () => {
  const { title, subtitle, modelImg, btnText } = reservationData
  //date
  const [startDate, setStartDate] = useState(new Date());
  //lock
  const [value, setValue] = useState('10:10');

  return <section className='relative top-96 z-30 pb-20 lg:py-[100px]'>
    <div className='container mx-auto'>
      {/*text*/}
      <div className='text-center'>
        <h2 className='h2 capitalize'>{title}</h2>
        <p className='mb-8 text-dark'>{subtitle}</p>
        <div className='flex justify-center mb-8'>
          <img src={modelImg} alt='' />
        </div>
      </div>
      {/*form*/}
      <form>
        <div className='flex flex-col lg:flex-row gap-y-4 items-center justify-between mb-8'>
          {/* date picker */}
          <div>
            <div className='flex items-center gap-x-[10px] font-third font-semibold text-dark text-base mb-3'>
              <FaCalendar />
              <div>Chọn ngày</div>
            </div>
            <DatePicker className='input' selected={startDate} onChange={(date) => setStartDate(date)} />
          </div>
        {/* time picker */}
          <div>
            <div className='flex items-center gap-x-[10px] font-third font-semibold text-dark text-base mb-3'>
              <FaClock />
              <div>Thời gian</div>
            </div>
            <TimePicker className='input' clearIcon={false} clockIcon={false} onChange={setValue} value={value} />
          </div>
          {/* number */}
          <div>
            <div className='flex items-center gap-x-[10px] font-third font-semibold text-dark text-base mb-3'>
              <FaUsers />
              <div>Số người?</div>
            </div>
            <input className='input' type='text' placeholder='1' />
          </div>
          {/* email */}
          <div>
            <div className='flex items-center gap-x-[10px] font-third font-semibold text-dark text-base mb-3'>
              <FaUsers />
              <div>Số điện thoại</div>
            </div>
            <input className='input' type='text' placeholder='Số điện thoại' />
          </div>
        </div>
        <div className='max-w-[316px] mx-auto flex justify-center'>
          <button variants={fadeIn('down', 'tween', 0.2, 1.6)} className='btn capitalize w-full lg:w-auto'>{btnText}</button>
        </div>
      </form>
    </div>
  </section>;
};

export default Reservation;
