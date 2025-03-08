import React, { useState } from 'react';
import LoginService from '../services/LoginService';
import { Link} from 'react-router-dom';

const Login = () => {
    const [email , setEmail ] = useState("");
    const [password , setPassword ] = useState("");
    const data = {username: email, password: password}
    function LoginRequest (event) {
        event.preventDefault(); // Ngăn chặn hành vi mặc định của form
        var respone = LoginService.Login(data)
        window.localStorage.setItem('ACCESS_TOKEN' , respone)
        if(respone.success) {
            
        }
    }

    return (<>
            {/* login */}
            <form onSubmit={LoginRequest}  className='w-1/2 h-full bg-[#f5f5f5] text-black flex flex-col p-20 justify-between'>
                <h1 className='text-xl text-center text-[#060606] font-semibold'>Xin chào đã đến nhà hàng chúng tôi</h1>
                <div className=' w-full flex flex-col max-w-[500px]'>
                    {/* title */}
                    <div className='w-full flex flex-col mb-2'>
                        <h3 className='text-2xl text-center font-semibold mb-2'>Đăng Nhập</h3>
                        {/* <p className='text-base mb-2'>Moi Dang Nhap</p> */}
                    </div>
                    {/* email & password */}
                    <div className='w-full flex flex-col'>
                        <p className='text-sm mb-2'>Email</p>
                        <input value= {email} onChange={(e) => setEmail(e.target.value)}  type='email' placeholder='Nhập vào email' className='input w-full text-black/50 py-2 my-2 mb-2 bg-transparent border border-black placeholder:font-light focus:ring-1 focus:ring-accent transition-all' />

                        <p className='text-sm mb-2'>Password</p>
                        <input value= {password} onChange={(e) => setPassword(e.target.value)} type='password' placeholder='Nhập vào mật khẩu' className='input w-full text-black/50 py-2 my-2 bg-transparent border border-black placeholder:font-light focus:ring-1 focus:ring-accent transition-all' />
                    </div>
                    {/* remember & forgot pass */}
                    <div className='w-full flex items-center justify-between'>
                        <div className='w-full flex items-center'>
                            <input type='checkbox' className='w-4 h-4 mr-2' />
                            <p className='text-sm'>Nhớ mật khẩu</p>
                        </div>
                        <Link to="/quen-mat-khau"  className='text-sm font-medium whitespace-nowrap cursor-pointer underline underline-offset-2'>Quên mật khẩu?</Link>
                    </div>

                    <div className='w-full flex flex-col my-4'>
                        <button  type='submit' className='btn text-xl my-2 capitalize w-full lg:max-w-full'>Đăng Nhập</button>
                    </div>
                </div>


                <div className='w-full flex items-center justify-center'>
                    <p className='text-sm font-normal text-[#060606]'>@ <span className=' font-semibold underline underline-offset-2 cursor-pointer'>Gimji restaurant</span></p>
                </div>
            </form>
        </>
    );
};

export default Login;
