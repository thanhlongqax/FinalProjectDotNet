import React, { useState  , useEffect } from 'react';
import DishesCard from './DishesCard';
import productService from './../services/ProductService';
import queryString from 'query-string';
import Pagination from './Pagination';
import { useParams } from 'react-router-dom';
const Dishes = () => {
    const {id} = useParams();
    const [products , setProducts]  = useState([])
    const [pagination , setPagination] = useState({
      page :1 , 
      limit : 6 , 
      totalRows : 1
    });
    const [filter , setFilter] = useState({
      limit : 6 ,
      page : 1,
      id : id
    });
    function handlePageChange(newPage){
      setFilter({
        ...filter,
        page : newPage
      });
    };
    // Sử dụng useEffect để theo dõi thay đổi của id từ useParams() và cập nhật filter tương ứng
    useEffect(() => {
        setFilter(prevFilter => ({
            ...prevFilter,
            id: id // Cập nhật id trong filter với giá trị mới từ useParams()
        }));
    }, [id]);
    async function getProductAll (filter) {
      const paramsString = queryString.stringify(filter);
      const res = await productService.getProductAll(paramsString);
      setProducts(res);
      setPagination(filter);
    } 
    async function getProductByCategory(categoryCode , filter){
      const paramsString = queryString.stringify(filter);
      const res = await productService.getProductByCategory(categoryCode, paramsString);
      setProducts(res);
      setPagination(filter);
    }
    useEffect(() => {
        if(id == null){
          getProductAll(filter);
        }
        else if (id == 'tat-ca-mon-an'){
          getProductAll(filter);
        }
        else{
          getProductByCategory(id, filter);
        }
    }, [filter]);
    return <div className=' min-h-screen flex flex-col justify-between items-center px-5'>
        <div className='flex flex-wrap gap-8 justify-center'>
            {products.map(product =>
                <DishesCard key={product.productID} id={product.productID} img={product.imageSrc} title={product.name} price={product.price}   />
            )}
        </div>
        <Pagination
          pagination={pagination}
          onPageChange={handlePageChange}
        />
    </div>;
};

export default Dishes;