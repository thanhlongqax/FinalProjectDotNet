import Footer from "../../components/Footer";
import Hero from "../../components/Hero";
const NoLayout = () => {
    return (  
        <div className='h-full bg-pattern bg-repeat max-w-[1800px] mx-auto overflow-hidden'>
            <Hero />
            <div>truy cập lỗi trang</div>
            <Footer />
      <div className='h-[530px] md:h-[380px]'></div>
        </div>
    );
}
export default NoLayout;