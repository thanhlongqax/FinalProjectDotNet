import React from "react";

const ForgotPassword = () => {
  return (
    <>
      {/* login */}
      <form className="w-1/2 h-full bg-[#f5f5f5] text-black flex flex-col p-20 justify-between">
        <h1 className="text-2xl text-center text-[#060606] font-semibold">
          Quên mật khẩu?
        </h1>
        <div className=" w-full flex flex-col max-w-[500px]">
          {/* title */}
          <div className="w-full flex flex-col mb-2">
            <h3 className="text-2xl text-center font-third mb-2">
              Vui lòng nhập gmail để lấy lại mật khẩu.
            </h3>
            {/* <p className='text-base mb-2'>Moi Dang Nhap</p> */}
          </div>
          {/* email & password */}
          <div className="w-full flex flex-col">
            <p className="text-sm mb-2">Email</p>
            <input
              type="email"
              placeholder="Enter your Email"
              className="input w-full text-black/50 py-2 my-2 mb-2 bg-transparent border border-black placeholder:font-light focus:ring-1 focus:ring-accent transition-all"
            />
          </div>
          {/* remember & forgot pass */}

          <div className="w-full flex flex-col my-4">
            <button className="btn text-xl my-2 capitalize w-full lg:max-w-full">
              Gửi thông tin
            </button>
          </div>
        </div>

        <div className="w-full flex items-center justify-center">
          <p className="text-sm font-normal text-[#060606]">
            @{" "}
            <span className=" font-semibold underline underline-offset-2 cursor-pointer">
              Gimji restaurant
            </span>
          </p>
        </div>
      </form>
    </>
  );
};

export default ForgotPassword;
