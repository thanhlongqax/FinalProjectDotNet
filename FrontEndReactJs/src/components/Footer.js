import React from 'react';

import Newletter from './Newsletter';
import Socials from './Socials';
import { footerData } from '../data';
import Copyright from './Copyright';

const Footer = () => {
  const { contact, hours, social } = footerData;
  return <footer className='relative top-96 z-20 bg-dark lg:bg-transparent lg:min-h-[620px] lg:bg-footer lg:bg-center lg:bg-no-repeat pt-20'>
    <div className='container mx-auto h-full'>
      <div className='h-full flex flex-col gap-y-12'>
        {/* new letter */}
        <div>
          <Newletter />
        </div>
        {/* info */}
        <div className='flex flex-col lg:flex-row lg:gap-x-[130px] gap-y-12 lg:gap-y-0 lg:mb-12'>
          {/* contact */}
          <div className='flex-1 lg:max-w-[170px]'>
            <div className='capitalize text-[20px] lg:text-[22px] font-normal text-white font-primary mb-[22px]'>{contact.title}</div>
            <div>{contact.address}</div>
            <div>{contact.phone}</div>
          </div>
          {/* program */}
          <div className='flex-1'>
            <div className='capitalize text-[20px] lg:text-[22px] font-normal text-white font-primary mb-[22px]'>{hours.title}</div>
            <div className='flex gap-x-[46px]'>
              {hours.program.map((item, index) => {
                return (
                  <div className='capitalize' key={index}>
                    <div>
                      <div>{item.days}</div>
                      <div className='text-[20px]'>{item.hours}</div>
                    </div>
                  </div>
                );
              })}
            </div>
          </div>
          {/* social */}
          <div className='flex-1 lg:max-w-[280px] mb-12 '>
            <div className='capitalize text-[20px] lg:text-[22px] font-normal text-white font-primary mb-[22px]'  >{social.title}</div>
            <Socials />
          </div>
        </div>
      </div>
      <Copyright />
    </div>
  </footer>;
};

export default Footer;
