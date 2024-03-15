import React, { useState, useEffect } from 'react';
import Link from 'next/link';
import { MdNotifications,MdDelete } from 'react-icons/md';
import { useAuth } from '../AuthContext';
import { useRouter } from 'next/router';
import axios from 'axios';
import SessionCheck from '../Session';



const ServiceProviderNav = () => {

  const [profile, setProfile] = useState({});

  const [allNotification, setAllNotification] = useState([]);
  const [error, setError] = useState('');
  const router = useRouter();
  const { user, login, logout, Tkey } = useAuth() || {}; 
 

  const [isDropdownOpen, setDropdownOpen] = useState(false);
  const [isDropdown, setDropdown] = useState(false);

  const toggleDropdown = (event) => {
    event.stopPropagation();
    setDropdownOpen(!isDropdownOpen);
  };

  const toggleProfile = (event) => {
    event.stopPropagation();
    setDropdown(!isDropdown);
  };
  console.log("User" + user);
  console.log("Token" + Tkey );
 
  useEffect(() => {
    // Check if the user is authenticated before fetching the profile
    if ( login) {
      GetProfile();
    //   GetNotification();
    } else {
      // Redirect to login page or handle unauthenticated user
      router.push('/Auth/Login');
    }
  }, []);

  const GetNotification = async () => {
    try {
      const response = await axios.get('', {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      console.log(response.data);
      console.log(response.success);
      if (response.data) {
        console.log('notification:', response.data);
        console.log(response.data.data);
        setAllNotification(response.data);
      } else {
        console.log('No products available');
        setError('No products available');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch products: ${error.message}`);
    }
  };
  
 
  const GetProfile = async () => {
    try {
      const response = await axios.get('https://localhost:44307/api/GetFile', {
        withCredentials: true,
        headers: {
          'Authorization': `${Tkey}`,
          'Content-Type': 'application/json',
        },
        responseType: 'arraybuffer', // Important: Set the responseType to 'arraybuffer'
      });

      if (response.data) {
        const imageSrc = `data:image/png;base64,${Buffer.from(response.data, 'binary').toString('base64')}`;
        setImageSrc(imageSrc);
        setProfile(response.data);
      } else {
        console.log('No profile available');
        setError('No profile available');
      }
    } catch (error) {
      console.error('Failed:', error);
    }
  };


//   const handleEditClick = (profile) => {

//     router.push({
//         pathname: '/Manager/EditProfile',
//         query: {
//           id: profile.id,
//           firstName: profile.firstName,
//           phoneNumber:profile.phoneNumber,
//           profilePic:profile.profilePic,
          
//         },
//       });
      
//   };
//   const handleDeleteClick = async (Serial) => {
//     console.log(`Delete clicked for product with ID: ${Serial}`);
//     try {
//       const respons = await axios.delete(`http://localhost:7000/manager/deleteNotification/${Serial}`);

//       GetNotification();
//       if (respons.data.success) {
//         console.log('Notification deleted successfully');
        
//         // Update the UI state to remove the deleted product
//         setAllNotification(prevNotification => prevNotification.filter(notification => notification.Serial !== Serial));
//       } else {
        
//         console.log('Failed to delete notification');
        
//         setError('');
//       }
//     } catch (error) {
//       console.error('Delete failed:', error);
//       // setError(`An error occurred while deleting the notification: ${error.message}`);
//     }
//   };
  
  

  return (
    <div>
      <SessionCheck />
    <div className="grid grid-cols-12 gap-3 pr-6 pl-6 text-xl font-semibold">
      {/* Header */}
      <header className="col-span-12 bg-gradient-to-r from-[#006266] to-[#024f52] text-white p-4 flex justify-between items-center  shadow-md">
        
        <nav className="flex space-x-4 ">
        <Link href="/ServiceProvider/ServiceProviderDashboard">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
    Manage Money
    </div>
  </Link>
  <Link href="/ServiceProvider/ProvideHelp">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Provide Help
    </div>
  </Link>
  
  <Link href="/">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Website
    </div>
  </Link>
  
  <Link href="/ServiceProvider/CreateCampaign">
  <div className="hover:text-yellow-300 transition duration-300 cursor-pointer">
      Create Campaign
    </div>
  </Link>
  <Link href="/Auth/Login">
    <div className="hover:text-yellow-300 transition duration-300 cursor-pointer ml-72">
      Logout
    </div>
  </Link>
  
  <div className="notification-container relative">
  <div className="hover:text-yellow-300 transition duration-300 cursor-pointer" onClick={toggleDropdown}>
    <MdNotifications size={22} color="white" />
    {allNotification && (
      <div className="absolute top-1 right-3 bg-red-500 text-white rounded-full px-1 text-xs">
        {allNotification.length}
      </div>
    )}
  </div>

  {isDropdownOpen &&  (
    <div className="notification-card absolute top-full right-1 bg-[#2d3436] border border-gray-300 shadow-md rounded-md p-2 mt-5 w-80">
      <div className="flex items-center justify-between font-bold border-b pb-2 mb-2">
        <span>Notifications</span>
        <MdNotifications size={18} color="#333" />
      </div>
      <table className="w-full text-[10px]">
        <tbody>
          {allNotification.map((notification) => (
            <tr key={notification.Serial} className="p-2 border rounded hover:bg-blue cursor-pointer">
              <td>{notification.Message}</td>
              <td>{notification.time}</td>
              <td>{notification.date}</td>
              <td><MdDelete size={22} color="#ff6b6b" onClick={() => handleDeleteClick(notification.Serial)} /></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )}
</div>

 
</nav>
<div className="flex items-center cursor-pointer" >
          <span className="ml-2 text-lg font-semibold mr-3 "onClick={toggleProfile} >{user}</span>        
          <img
            src={`http://localhost:7000/manager/getimage/${profile.profilePic}`}
            alt={profile.firstName}
            className="w-10 h-10 object-cover rounded-full "
            onClick={toggleProfile} 
          />
          
        </div>
      </header>

        
      </div>
      
      {isDropdown  && (
    <div className=" absolute  right-1 bg-gradient-to-r from-[#55606b] to-[#424f5b] text-white  p-2 mt-1 w-64 mr-7 rounded-md">
      <div className="flex flex-col items-center justify-between font-bold  mb-2">
        <div className=" mb-6">

        <img
            src={``}
            alt={profile.firstName}
            className=" w-44 h-44 rounded-md "
          />
            
            <div className="ml-6">
              <h1 className="text-3xl font-bold mt-2">{profile.lastName}</h1>
              <p className="text-lg">{profile.email}</p>
            </div>
          </div>
          <button className="bg-white text-blue-500 px-4 ml-5 py-2 rounded-md hover:bg-blue-500 hover:text-white transition duration-300"
          onClick={() => handleEditClick(profile)}
          >
            Edit Profile
          </button>
          </div>
    </div>
  )}

    </div>


  );
};


export default ServiceProviderNav;
