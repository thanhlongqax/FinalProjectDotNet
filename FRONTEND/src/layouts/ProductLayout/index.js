import Footer from "../../components/Footer";
import Hero from "../../components/Hero";
import { Link} from "react-router-dom";
import { FaSearch } from "react-icons/fa";
import { useEffect, useState } from "react";
import categoryService from './../../services/CategoryService';
const ProductLayout = ({children}) => {
  const [categories , setCategories] = useState([]);
  async function getCategoryAll () {
    const res = await categoryService.getCategoryAll();
    console.log(res)
    setCategories(res);
  } 
  useEffect(() => {
    getCategoryAll();
  }, []);
  return (
    <div className="h-full bg-pattern bg-repeat max-w-[1800px] mx-auto overflow-hidden">
      <Hero />
      <div className=" bg-pattern">
        <div className=" flex flex-row-reverse ">
          <label className="relative block w-[500px]  mt-5 right-[110px]">
            <span className="sr-only">Tìm kiếm</span>

            <span className="absolute inset-y-0 left-0 flex items-center pl-2">
              <svg className="h-5 w-5 fill-slate-300" viewBox="0 0 20 20">
                {" "}
                <FaSearch />
              </svg>
            </span>

            <input
              className="placeholder:italic placeholder:text-slate-400 block bg-white w-full border border-slate-300 rounded-md py-2 pl-9 pr-3 shadow-sm focus:outline-none focus:border-sky-500 focus:ring-sky-500 focus:ring-1 sm:text-sm"
              placeholder="Tìm kiếm"
              type="text"
              name="search"
            />
          </label>
        </div>
        <div className="w-full h-screen flex justify-start mt-8">
        
          <div className=" relative w-1/4 flex flex-col ml-4 ">

            <table className=" font-third text-xl text-left indent-4 h-[450px] border border-black hover:table-fixed shadow-[rgba(0,0,0,0.24)_0px_3px_8px] rounded-lg">
              <thead>
                <tr className="h-[50px] bg-accent/40 text-accent ">
                  <th>Danh mục</th>
                </tr>
              </thead>
              <tbody className=" border border-black rounded-lg">
                <tr className=" border border-black">
                  <td>
                    <Link to="/thuc-don/tat-ca-mon-an">Tất cả món ăn</Link>
                  </td>
                </tr>
                {categories.map(category => (
                <tr className=" border border-black" key={category.codeValue}>
                  <td>
                    <Link to={`/thuc-don/${category.codeValue}`} >{category.name}</Link>
                  </td>
                </tr>
                ))} 
              </tbody>
            </table>

          </div>
          <div className="w-3/4 h-full flex flex-col">
            {children}
          </div>
        </div>
      </div>
      <Footer />
      <div className="h-[530px] md:h-[380px]"></div>
    </div>
  );
};
export default ProductLayout;
