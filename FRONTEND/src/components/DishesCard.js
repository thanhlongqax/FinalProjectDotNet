import { Link } from 'react-router-dom'
const DishesCard = (props) => {
  return (
    <div className='w-full lg:w-1/4 p-5 shadow-[rgba(0,0,0,0.24)_0px_3px_8px] rounded-lg text-black'>
      <div className="h-30 w-50 rounded-xl overflow-hidden">
        <img className='object-cover h-full w-full' src={props.img} alt='img' />
      </div>
      <div className='space-y-4'>
        <div className='text-center text-xl pt-6'>{props.title}</div>
      </div>
      <div className='flex flex-col items-center justify-center gap-4'>
        <h3 className='text-lg'>{props.price} đ</h3>
      </div>
      <div className='flex justify-center pt-4'>
        <button className="h-10 px-6 rounded-md bg-red-600 text-white">
        <Link to={`/chi-tiet/${props.id}`}>Xem chi tiết</Link>
        </button>
      </div>
    </div>
  );
};

export default DishesCard;