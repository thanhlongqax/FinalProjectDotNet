import CoverImg from '../../assets/img/login/dau-bep.png';
const AuthsLayout = ({children}) => {
    return (
        <div className='w-full h-screen flex items-start'>
            {/* img */}
            <div className=' relative w-1/2 h-full flex flex-col'>
                <img src={CoverImg} className="w-full h-full object-cover" />
            </div>
            {children}
        </div>
    );
};

export default AuthsLayout;
