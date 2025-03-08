import React from 'react';
import SimpleCard from './SimpleCard';

const Cards = () => {
    return <div className=' min-h-32 flex flex-col justify-between items-center px-3 py-2'>
        {/* <h1 className='text-4xl font-semibold text-center pt-24 pb-10'> Mon An</h1> */}
        <div className='flex flex-wrap gap-5 justify-center'>
            <SimpleCard title="Doanh thu tháng" subtitle="1,265,000 đ" />
            <SimpleCard title="Doanh thu tháng" subtitle="1,265,000 đ" />
            <SimpleCard title="Doanh thu tháng" subtitle="1,265,000 đ" />
            <SimpleCard title="Doanh thu tháng" subtitle="1,265,000 đ" />
        </div>
    </div>;
};

export default Cards;