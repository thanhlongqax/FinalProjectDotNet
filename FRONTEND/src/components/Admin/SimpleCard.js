import React from 'react';

const SimpleCard = (props) => {
    return <div className='w-120 lg:w-60 p-5 shadow-[rgba(0,0,0,0.24)_0px_3px_8px] rounded-lg bg-white text-black'>
        <div className=''>
            <h3 className='font-semibold text-center text-xl'>{props.title}</h3>
        </div>
        <div className='flex flex-col items-center justify-center gap-4'>
            <h3 className=' font-semibold text-lg'>{props.subtitle}</h3>
        </div>
    </div>;
};

export default SimpleCard;