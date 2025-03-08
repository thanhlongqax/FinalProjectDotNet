import { PhotoIcon } from '@heroicons/react/24/solid';
import { Typography, Card } from "@material-tailwind/react";
import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import productService from '../../services/ProductService';
import categoryService from './../../services/CategoryService';
import { CkEditor } from './CkEditor';
import imageService from '../../services/ImageService';

export default function EditProducts() {
    const { productID } = useParams();
    const [product, setProduct] = useState(null);
    const [categories , setCategory] = useState([]);
    const [formData, setFormData] = useState({
        name: '',
        price: '',
        nsn: '',
        category: '',
        image1: '',
        image2: '',
        image3: '',
        description: '',
        meta: ''
    });
    const [selectedFiles, setSelectedFiles] = useState({
        photo1: null,
        photo2: null,
        photo3: null
    });
    const [status , setStatus] = useState({
        StatusCode:0,
        Message:''
    })
    // Handler for file selection
    const handleFileSelect = (event, name) => {
        const file = event.target.files[0];
        setSelectedFiles(prevState => ({
            ...prevState,
            [name]: file
        }));
    };
    async function getCategoryAll(){
        const res = await categoryService.getCategoryAll();
        setCategory(res);
    }
    async function getProductById(productID) {
        const res = await productService.getProductById(productID);
        setProduct(res);
        setFormData({
            productID: res.productID || '',
            name: res.name || '',
            price: res.price || '',
            nsn: res.nsn || '',
            category: res.category ? res.category.codeValue : '',
            image1: res.image1 || '',
            image2: res.image2 || '',
            image3: res.image3 || '',
            description: res.description || '',
            meta: res.productID || ''
        });
        setSelectedFiles({
            photo1: res.image1 ? { url: `http://localhost:5000/api/images/${res.image1}` } : null,
            photo2: res.image2 ? { url: `http://localhost:5000/api/images/${res.image2}` } : null,
            photo3: res.image3 ? { url: `http://localhost:5000/api/images/${res.image3}` } : null,
        });
    }
    async function updateImage(file){
       const res = await imageService.CreateImage(file);
       setStatus(res);
       return res;
    }
    async function updateProduct(productID , payload){
        await productService.updateProduct(productID, payload);
    }
    useEffect(() => {
        if (productID) {
            getProductById(productID);
            
        }
        getCategoryAll();
    }, [productID]);
    useEffect(() => {
        if (categories.length > 0) {
            setFormData(prevFormData => ({
                ...prevFormData,
                category: categories[0].codeValue, // Đặt giá trị mặc định là category đầu tiên trong danh sách
            }));
        }
    }, [categories]);
    
    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleDescriptionChange = (newDescription) => {
        setFormData(prevFormData => ({
            ...prevFormData,
            description: newDescription
        }));
    };
    
    async function editProduct(e) {
        e.preventDefault();
        const res = await updateImage(selectedFiles.photo1);
        setFormData({
            productID: formData.productID || '',
            name: formData.name || '',
            price: formData.price || '',
            nsn: formData.nsn || '',
            category: formData.category ? formData.category.codeValue : '',
            image1:  res.message || '',
            image2: formData.image2 || '',
            image3: formData.image3 || '',
            description: formData.description || '',
        });
        const updateFormData = {
            productID: formData.productID || '',
            name: formData.name || '',
            price: formData.price || '',
            nsn: formData.nsn || '',
            categoryId : formData.category || '',
            image1: res.message || '',
            image2: formData.image2 || '',
            image3: formData.image3 || '',
            description: formData.description || '',
        }
        updateProduct(productID , updateFormData);
        try {
            // Thực hiện API PUT với formDataToSubmit
            await productService.updateProduct(productID,updateFormData);
            console.log('Product updated successfully!');
            // Xử lý sau khi sản phẩm đã được cập nhật thành công
        } catch (error) {
            console.error('Error updating product:', error);
            // Xử lý lỗi nếu có
        }
    };

    if (!product) {
        return <div>Loading...</div>;
    }

    return (
        <Card className="h-full w-full mt-3">
            <form onSubmit={editProduct}>
                <div className="space-y-12">
                    <div className="border-b border-gray-900/10 pb-12 px-10">
                        <div className="flex flex-col lg:flex-row items-center justify-between gap-8">
                            <div className="pt-8">
                                <Typography variant="h5" color="blue-gray">
                                    Sản phẩm
                                </Typography>
                                <Typography color="gray" className="mt-1 font-normal">
                                    Chỉnh sửa sản phẩm
                                </Typography>
                            </div>
                        </div>

                        <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className="sm:col-span-3">
                                <label htmlFor="name" className="block text-l font-semibold leading-6 text-gray-900">
                                    Tên sản phẩm
                                </label>
                                <div className="mt-2">
                                    <input
                                        type="text"
                                        name="name"
                                        id="name"
                                        className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                        placeholder='Tên sản phẩm'
                                        value={formData.name}
                                        onChange={handleChange}
                                    />
                                </div>
                            </div>

                            <div className="sm:col-span-3">
                                <label htmlFor="price" className="block text-l font-semibold leading-6 text-gray-900">
                                    Giá
                                </label>
                                <div className="mt-2">
                                    <input
                                        type="number"
                                        name="price"
                                        id="price"
                                        className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                        placeholder='Giá'
                                        value={formData.price}
                                        onChange={handleChange}
                                    />
                                </div>
                            </div>
                        </div>

                        <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className="sm:col-span-3">
                                <label htmlFor="nsn" className="block text-l font-semibold leading-6 text-gray-900">
                                    Nsn
                                </label>
                                <div className="mt-2">
                                    <input
                                        type="text"
                                        name="nsn"
                                        id="nsn"
                                        className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                        placeholder='Nsn'
                                        value={formData.nsn}
                                        onChange={handleChange}
                                    />
                                </div>
                            </div>
                            <div className="sm:col-span-3">
                                <label htmlFor="category" className="block text-l font-semibold leading-6 text-gray-900">
                                    Danh mục
                                </label>
                                <div className="mt-2">
                                    <select
                                        name="category"
                                        id="category"
                                        className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                        value={formData.category}
                                        onChange={handleChange}
                                    >
                                        <option value="">Chọn danh mục</option>
                                        {categories.map((category) => (
                                            <option key={category.codeValue} value={category.codeValue}>
                                                {category.name}
                                            </option>
                                        ))}
                                    </select>
                                </div>
                            </div>
                        </div>

                        <div>
            {['photo1', 'photo2', 'photo3'].map((photoKey, index) => (
                <div className="col-span-full mt-5" key={index}>
                    <label htmlFor={photoKey} className="block text-lg font-semibold leading-6 text-gray-900">
                        Hình {index + 1}
                    </label>
                    <div className="mt-2 flex items-center gap-x-3">
                        {!selectedFiles[photoKey] ? (
                            <PhotoIcon className="h-12 w-12 text-gray-300" aria-hidden="true" />
                        ) : (
                            selectedFiles[photoKey].url ? (
                                <img src={selectedFiles[photoKey].url} alt={`Selected Image ${index + 1}`} className="h-12 w-12" />
                            ) : (
                                <img src={URL.createObjectURL(selectedFiles[photoKey])} alt={`Selected Image ${index + 1}`} className="h-12 w-12" />
                            )
                        )}
                        <input
                            type="file"
                            accept="image/*"
                            onChange={(e) => handleFileSelect(e, photoKey)}
                            style={{ display: 'none' }}
                            id={photoKey}
                            name={photoKey}
                        />
                        <label htmlFor={photoKey} className="rounded-md bg-white px-2.5 py-1.5 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 cursor-pointer">
                            Choose File
                        </label>
                        {selectedFiles[photoKey] && selectedFiles[photoKey].name && <span>{selectedFiles[photoKey].name}</span>}
                    </div>
                </div>
            ))}
        </div>

                        <div className="col-span-full mt-5">
                            <label htmlFor="description" className="block text-lg font-semibold leading-6 text-gray-900">
                                Mô tả
                            </label>
                            
                            <CkEditor value={formData.description} onChange={handleDescriptionChange}/>
                            
                        </div>

                        <div className="col-span-full">
                            <label htmlFor="meta" className="block text-lg font-semibold leading-6 text-gray-900">
                                Meta
                            </label>
                            <div className="mt-2">
                                <input
                                    type="text"
                                    name="meta"
                                    id="meta"
                                    className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                    value={formData.meta}
                                    onChange={handleChange}
                                />
                            </div>
                        </div>
                    </div>
                
                    <div className="mt-6 flex items-center justify-end gap-x-6" style={{ marginBottom: '20px' ,marginRight: '20px' , marginTop:'10px' }}>
                        <button type="button" className="text-sm font-semibold leading-6 text-gray-900">
                            Cancel
                        </button>
                        <button
                            type="submit"
                            className="rounded-md bg-accent px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-accent-hover focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                        >
                            Save
                        </button>
                    </div>
                </div>
            </form>
        </Card>
    );
}
