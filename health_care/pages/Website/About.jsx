import React from 'react'
import Image from 'next/image';

const About = () => {
  return (
    <div className="max-w-full  mx-auto  p-8 bg-gradient-to-r from-[#F0F7F6] to-[#e1e8e7] rounded-md shadow-lg text-black flex items-center">
      <div className="flex-shrink-0 w-[350px] h-[360px] overflow-hidden  mt-6 ml-16">
      <Image
          src="/about1.jpg" // Adjust the path based on your project structure
          alt="about"
          className="w-full h-full object-cover "
          width={200} // Set your desired width
          height={200} // Set your desired height
        />
      </div>

<div className="w-[500px] h-[400px] ml-[120px] pl-8">
        <h1 className="text-2xl font-bold mb-2 text-[#56b5a9] mt-5">About Us</h1>
        <p className="text-3xl mb-4 text-justify font-bold text-gray-600">
        Welcome to HealthConnect, your premier destination for all things healthcare and blood donation.
</p>
<p className="text-lg mb-4 text-justify">
  At HealthConnect, compassion and well-being are at the core of what we do. Our intuitive platform ensures seamless access to resources, empowering healthier lives.
</p>
<p className="text-lg mb-4 text-justify">
  We are dedicated to ensuring your well-being and contributing to a thriving community. Your health and care are our priority,
</p>     
      </div>
      
      
    </div>
  );
};


export default About