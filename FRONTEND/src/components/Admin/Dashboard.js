import React from 'react'
import Cards from './Cards';
import LineChart from './LineChart';
import BarChart from './BarChart';

function Dashboard() {
    return (
        <div className='pt-2 h-full flex-col max-w-[1200px] mx-auto'>
            <Cards />
            <div className='flex flex-col md:flex-row justify-center'>
                <LineChart />
                <BarChart />
            </div>


        </div>
    )
}

export default Dashboard


