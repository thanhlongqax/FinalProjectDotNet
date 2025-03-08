import Footer from "../../components/Footer";
import Hero from "../../components/Hero";
import Menu from "../../components/Menu";
import Reservation from "../../components/Reservation";
import AboutUs from "../../components/AboutUs";

const HomeLayout = () => {
  return (
    <div className='h-full bg-pattern bg-repeat max-w-[1800px] mx-auto overflow-hidden'>
      <Hero />
      <AboutUs />
      <Menu />
      <Reservation />
      <Footer />
      <div className='h-[530px] md:h-[380px]'></div>
    </div>
  );
};
export default HomeLayout;