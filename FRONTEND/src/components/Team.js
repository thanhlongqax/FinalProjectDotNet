import React from 'react';
import { teamData } from '../data';


const Team = () => {
  // Destructure dữ liệu từ teamData
  const { pretitle, title, sub1, sub2, name, occupation, signatureImg, chefImg } = teamData;

  // Trả về JSX của component
  return (
    <div className='h-full bg-pattern bg-repeat max-w-[1800px] mx-auto overflow-hidden'>
      {/* Section hiển thị thông tin về đội ngũ */}
      <section className='relative z-10 lg:top-44 top-24 lg:mb-0 -mb-44 min-h-[720px]'>
        <div className='container mx-auto'>
          <div className='flex flex-1 flex-col lg:flex-row lg:gap-x-[120px] items-center lg:items-start'>
            {/* Phần text */}
            <div className='flex-1 text-center font-third lg:text-left lg:pt-16'>
              <div className='pretitle'>{pretitle}</div>
              <h2 className='h2 capitalize'>{title}</h2>
              <p className='mb-[60px]'>{sub1}</p>
              <p>{sub2}</p>
              <div className='my-[26px] text-third'>
                <div className='text-2xl capitalize font-semibold text-accent'>{name}</div>
                <div className='text-[15px]  capitalize font-semibold text-grey/70'>{occupation}</div>
              </div>
              <div className='flex justify-center lg:justify-start mb-6 lg:mb-0 '>
                <img src={signatureImg} alt='' />
              </div>
            </div>
            {/* Phần hình ảnh */}
            <div className='flex-1 '>
              <img src={chefImg} alt='' />
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Team;

