import React from 'react';
import { aboutData } from '../data';
import { motion } from 'framer-motion';
import { plateVariants, staggerContainer, fadeIn } from '../animation/variants';

const AboutUs = () => {
    const { pretitle, title, subtitle, btnText, image } = aboutData;
    return <section className='min-h-[620px] bg-pattern'>
        <div className='container mx-auto min-h-[620px]'>
            <motion.div
                variants={staggerContainer}
                initial='hidden'
                whileInView={'show'}
                viewport={{ once: false, amount: 0.6 }}
                className='min-h-[620px] flex flex-col lg:flex-row items-center'>
                {/*text*/}
                <motion.div
                    variants={fadeIn('right', 'tween', 0.2, 1.8)}
                    className=' flex-1 text-center lg:text-left'>
                    <div className='pretitle'> {pretitle} </div>
                    <h2 className='h2 capitalize'> {title}</h2>
                    <p className='mb-8 max-w-[560px] font-third'>{subtitle}</p>
                    {/* <button className='btn capitalize mx-auto lg:mx-0'>{btnText}</button> */}
                </motion.div>
                {/*img*/}
                <motion.div
                    variants={plateVariants}
                    className='-mb-[300px] -mr-[186px] z-10'>
                    <img src={image} alt='' />
                </motion.div>
            </motion.div>
        </div>
    </section>;
};

export default AboutUs;
