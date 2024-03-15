import Navbar from '../Components/Navbar';
import { useRouter } from 'next/router';
import '@/styles/globals.css'
import { AuthProvider } from './AuthContext';

export default function App({ Component, pageProps }) {
  const router = useRouter();
  const isLogin = router.pathname === '/Auth/Login';
  const isSignUp = router.pathname === '/Auth/Registration';
  const isUserNav = router.pathname === '/User/UserNav';
  const AdminNav = router.pathname === '/Admin/AdminNav';
  const isServiceProviderNav = router.pathname === '/ServiceProvider/ServiceProviderNav';
  const isDashboard = router.pathname === '/User/UserDashboard';
  const isAdminDashboard = router.pathname === '/Admin/AdminDashboard';
  const isServiceProviderDashboard = router.pathname === '/ServiceProvider/ServiceProviderDashboard';
  const isUserConsultancy = router.pathname === '/User/UserConsultancy';
  const isUserSendEmail = router.pathname === '/User/UserSendEmail';
  const isUserPost = router.pathname === '/User/UserPost';
  const isAddPost= router.pathname === '/User/AddPost';
  const isEditPost= router.pathname === '/User/EditPost';
  const isAddHelpPost= router.pathname === '/User/AddHelpPost';
  const isProvideHelp= router.pathname === '/ServiceProvider/ProvideHelp';
  const RequestForMoney= router.pathname === '/ServiceProvider/RequestForMoney';
  const AcceptDonateMoney= router.pathname === '/ServiceProvider/AcceptDonateMoney';
  const ReceiveMoney= router.pathname === '/ServiceProvider/ReceiveMoney';
  const TotalUser= router.pathname === '/Admin/TotalUser';
  const AdminHelppost= router.pathname === '/Admin/HelpPost';
  const MoneyDonor= router.pathname === '/Admin/MoneyDonor';
  const AvaiableDonor= router.pathname === '/Admin/AvaiableDonor';
  const AdminSendEmail= router.pathname === '/Admin/AdminSendEmail';
  const CreateCampaign= router.pathname === '/ServiceProvider/CreateCampaign';
  const DonateMoney= router.pathname === '/User/DonateMoney';
  const Campaign= router.pathname === '/User/Campaign';

 


  return (
    <div>
      {
        !isLogin && 
        !isSignUp && 
        !isUserNav &&  
        !isUserConsultancy && 
        !isUserSendEmail && 
        !isUserPost && 
        !isDashboard && 
        !isAddPost && 
        !isEditPost && !isAdminDashboard && !isServiceProviderDashboard && !AdminNav && !isServiceProviderNav &&
        !isAddHelpPost&& ! isProvideHelp && !RequestForMoney && !AcceptDonateMoney && !ReceiveMoney && !TotalUser && !AdminHelppost && !MoneyDonor && !AvaiableDonor && !AdminSendEmail && !CreateCampaign && !DonateMoney && !Campaign &&
        <Navbar />
      }
      <AuthProvider>
      <Component {...pageProps} />
      </AuthProvider>



      
    </div>
  );
}
