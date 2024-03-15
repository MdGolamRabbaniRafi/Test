import Link from 'next/link';
import Image from 'next/image';


const Navbar = () => {
  return (
    <div className="bg-[#ECFAF8] text-gray-500 p-3
     text-sm font-Poppins">
      <div className="container mx-auto flex items-center justify-center">
        <div className="mr-6 text-center flex ml-10">
        <div className="flex items-center">

     
      <div className='flex flex-row'>
      <div className="">
      <Image
          src="/logo1.png" // Adjust the path based on your project structure
          alt="Manager"
          className="w-12 h-10  ml-10"
          width={500} // Set your desired width
          height={400} // Set your desired height
        />
      </div>
        <h4 className="text-2xl font-bold font-lobster mt-1 ml-2"><span className='text-[#05497ee0]'>Health</span><span className='text-[#00b894]'>Care</span> </h4>
      </div>
    </div>
        </div>
        <div className="flex-grow">
          <ul className="flex justify-center font-semibold text-2xl cursor-pointer">
             <li className="mr-6 hover:text-[#4b7bec]">
               <Link href="/">Home</Link>
             </li>
             <li className="mr-6 hover:text-[#4b7bec]">
               <Link href="/Website/About">About</Link>
             </li>
             <li className="mr-6 hover:text-[#4b7bec]">
               <Link href="/Website/Contact">Contact</Link>
             </li>
             <li className="mr-6 hover:text-[#4b7bec]">
               <Link href="/Website/Team">Team</Link>
             </li>
             <li className="mr-6 hover:text-[#4b7bec]">
               <Link href="/Website/Service">Service</Link>
             </li>
           </ul>
        </div>
        <div className="text-center flex mr-10">
          <button className='bg-blue'>
          <Link href="/Auth/Registration" className='text-gray-600 text-2xl font-Poppins hover:text-[#20bf6b] font-bold mr-8'>Signup</Link>
          </button>
          
        </div>
      </div>
    </div>
  );
};

export default Navbar;
