import React, { useEffect, useState } from 'react';
import Footer from '../../components/Footer';
import { useParams } from 'react-router-dom';
import Hero from '../../components/Hero';
import productService from '../../services/ProductService';
const DetailsLayout = () => {
    const { id } = useParams();
    const [products , setProducts]  = useState([]);
    const getProductById = async (id) => {
        const res = await productService.getProductById(id);
        setProducts(res);
    }
    // Hàm để đếm số chữ của mô tả và xuống hàng sau mỗi 15 chữ
    const formatDescription = (description) => {
        if (!description) return '';
        const words = description.split(' ');
        let formattedDescription = '';
        let count = 0;
        for (let i = 0; i < words.length; i++) {
            count += words[i].length + 1;
            formattedDescription += words[i] + ' ';
            if (count >= 15) {
                formattedDescription += '\n';
                count = 0;
            }
        }
        return formattedDescription.trim();
    }

    function formatPrice(price) {
        // Kiểm tra xem price có tồn tại không
        if (typeof price !== 'undefined' && price !== null) {
          // Chuyển đổi giá tiền thành chuỗi
          let priceString = price.toString();
          // Tạo một mảng chứa mỗi ký tự của chuỗi giá tiền
          let priceArray = priceString.split('');
          // Sử dụng vòng lặp để chèn dấu chấm ngăn cách 3 số 0 vào giữa các chữ số
          for (let i = priceArray.length - 3; i > 0; i -= 3) {
            priceArray.splice(i, 0, '.');
          }
          // Trả về giá tiền đã được định dạng
          return priceArray.join('');
        } else {
          // Trả về một chuỗi rỗng nếu price không tồn tại
          return '';
        }
    }      
    useEffect(() => {
        getProductById(id);
    } , [id])
    return (
        <div className='w-full mx-auto bg-pattern'>
            <Hero />
            <div className='flex flex-col justify-between lg:flex-row gap-16 bg-pattern w-full h-screen items-start mt-8 ml-6'>
                    <React.Fragment key={products.productID}>
                        <div className='relative w-1/2 flex flex-col gap-5 shadow-[rgba(0,0,0,0.24)_0px_3px_8px]'>
                            <img src={products.imageSrc} alt='' className='w-full h-full object-cover rounded-xl' />
                        </div>
                        <div className='flex flex-col w-1/2 gap-4'>
                            <div className='text-third text-left'>
                                <h2 className='text-3xl text-accent font-bold'>{products.name}</h2>
                            </div>
                            <h2 className='text-3xl font-bold'>{formatPrice(products.price)} đ</h2>
                            <p className='text-gray-800 text-third'>{formatDescription(products.description)}</p>
                        </div>
                    </React.Fragment>
            </div>
            <Footer />
        </div>
    );
    
};

export default DetailsLayout;