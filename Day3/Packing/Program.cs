using System;

namespace Packing
{

    class PackingMain
    {

        public static void Main()
        {
            var input = GetInput();
            List<string> lstInput = input.Split("\n").ToList();
            int totalPriority = 0;

            foreach(string item in lstInput)
            {
                var firstCompartment = item.Substring(0,item.Length/2).ToCharArray();
                var secondCompartment = item.Substring(item.Length/2, item.Length/2).ToCharArray();

                var errors = firstCompartment.Where(x=>secondCompartment.ToList().Contains(x)).Distinct().ToList();

                foreach(var c in errors)
                {
                    totalPriority += ConvertToPriority(c);
                }
            }

            Console.WriteLine("Answer for part 1 is : {0}", totalPriority);

            var lstBadges = new List<char>();
            for(int i=0;i<lstInput.Count;i=i+3)
            {
                lstBadges.AddRange(lstInput[i].Trim()
                    .Where(x=>lstInput[i+1].Trim().ToList().Contains(x))
                    .Where(y=>lstInput[i+2].Trim().ToList().Contains(y))
                    .Distinct()
                    .ToList());
            }

            int badgePriority = 0;
            foreach(var c in lstBadges)
            {
                badgePriority += ConvertToPriority(c);
            }
            
            Console.WriteLine("Answer for part 2 is : {0}", badgePriority);
        }

        private static int ConvertToPriority(char c)
        {
            if((int)c>=(int)'a' && (int)c<=(int)'z') return (int)c-(int)'a'+1;
            if((int)c>=(int)'A' && (int)c<=(int)'Z') return 26+(int)c-(int)'A'+1;
            return -1;
        }

        private static string GetInput()
        {
            return @"RCMRQjLLWGTjnlnZwwnZJRZH
qnvfhpSbvSppNddNdSqbbmmdPrwttJVrVPDVrJtHtwPZhrPJ
BFpFzSSqSFFSvQsnWgCMjTLzng
DbWVcVRRdlLffvtqjTWNgQ
mJJMpsmrMrJSHJpsHrFHvBvgHvqfNvzffgTvfj
mMhPjmjmFPJhMSGGcDRlwRdcLGPc
qFcbmWFJqqWpRJcQWpqsQQQwSPCPrHRHCPdNZtSrSHwrNZ
jGMjGLhhhgTvghgtGVjnNCrPVwZSZffSNSwHZZdH
DvzDlvvhnjlMlglglGGhDLpqqcJWWtsmszpWbBBBmQmb
SPLPHQbJSbPsvTLmfDvVDctvWhcDlD
jdRRzzGgJqwrpMRMgdjlcVcWqfWWlfDlmmlWhB
rwgRGdpGprNNLQLsbZJPsn
GZhTVLztHrSzrRBz
MJWjMvsfSCLSnrJn
MjglcgWMdccvZGFtTDchLLLh
rgDHBgBjRgRTgwzwthBnQwmBtB
MsMpSfMsTGTFFLdFFFMFsnNmthNnzhthtwmWnznz
pZMpJdvJMGRHVJJTVHjb
TQVqZVBcBBdBfbpN
zvzrtCshrntCHslPMMMFpZHbNSpb
hLWhGLttsvLvrrWvhzVmQgwJZTRcggTjGcgT
SqRGLHtSbtNTbhjFTjDDpF
WwgJgmdmMdwPDVQQBBhSBFwV
JMPlmlSldWZmRqtLsRGRtvls
mZvmvPNmlNJPJzzmgNvNgdqqdBSpfHBqSsHqHfwpsffq
nhDQDrwLrVVnqfGnsBGBGGsH
VjCDMhbDjLjtFhtLhLhQjNZcZPwWWcczmvglgJJN
wwqnwZGGZqqMpMprpZqwGlLDtNDffdBdNVBmNGBN
TSTchTFbRLfLmVhNDm
SCLRvJQvRFTSRjqMqPZrZnrzZzjp
cJfqGjgGJcsgsPnghgBm
FHHbQQHLWLbPQThqQQRnZs
lLLMSCvrlFMwlSlFcNwqDVVpJcfjzVDf
cRdRDhsDFzPztwJdGP
CVqpCqCgSNfCSQBpjtBwtlBBHLlmGjGG
qfQfCVQfgQnVNpQCMqfcrFrwWDhrDnsvcRDsbc
nFWWzqWZQSqnJzNJzslJVsdV
vBBvsLvbBmBmRlGTNJJvRRTD
tBbpmmPwCmHpMHHMrPCCcSnZSgcFcZgWFscSfgth
LLssTJrqrpvrvvpJvdjggMlgzVgVggPlFPqz
HwZwCZfHNtbMzjgVnFPC
RSttfRwZDtBcZwQMQdrQsdTBQQmW
lJnNhMJqljlNhSrdWlGGGQHwwH
vbTpbCsTFCTmbSmcRfVCfRpwcPdwWQQrdwHwBHrPdwrLLB
sVTmDfmCTVmJjgSzzntDtt
DQtMjZHZHvMbwwTSpqLtpJ
FzVFlsNdVczWPzWcslVfSLqLsqJpSwwsJswLrf
dNFFWcmzWFGLWcdcFgvZvvRHQvjMHDMBGD
MVPTmPvbMgrTmmmmMRMvPvBwFGhhDCdFFwLCLdJhDGFRhG
fqqWfpZWzWsDwhwdhwqGLD
ZWSSftStnnplcQLSbVMBvTbrMlbrBvvl
FSsHDmtFLbbFbLGg
vrvzTzWzzzvppzSzTMnfTggjVgbgjbLjgPPnbGbVGL
pdMwrBpfwfSMTTWdMTpBDCBtmsmltslcBDCshDHs
RgbmfGtmRVgLLSVSnSrWWSHhnh
ccTvlvNppsFnbFnhnWnPHJ
pqNjDBjNNjvpZfmtjbCLbCmb
qsSVpSVfWqgNrVtWptpmSfqbPQljbHPHlDnljRSlwSnwQn
dcGBrMFMdLTGGdlwDwMRHwwMbjHP
CFBvhFhTLFCGvFchChBdBTJtsNpWqfVgtszprmVWNqNgvV
sjsTgNSNqSjgMmVPmmmrpH
RftCcWddRCZfPtCfcQZdcZDcrBllBFpVHprHWlHHpHJJmlFp
thPZRtLcDRdDCTTsqbnwjhvNjq
TQPtgfgdPcdSQhjwHhHBLS
RrqCqVVbJmVRJmsrzmJpWljlSHLSBwSSRWllWv
CVrDNbHrJHVMCbrDJsdFdFcPFZngMfFdTPfP
NNlZgndqmGVGGVZNWQmWmbhbbhpbbhtCbhtgCpCtMF
THfLPTzwJTJrvHRwwsbFbhfbMCpphVtBbB
RjrvzHLzPDvLzPHrTJVrwPndZQNlDZGndZWDdNNcmlQq
tjDsjDGtTjVVbQVCggvrbg
qrWWRBllRFrdlSMCdbSJCP
cZcncRnhphpZWRNtrmsrGpHffmwH
qpRjdcqTcMbbMRTwtnplnwnhPzhBhw
FSFLvNrsPNrsGSLsrFSGfnwBQwZnZwhQQLwwQhnn
sWNVmVmCFNWGsCrrjRTmMjRjPRqgJqJg
sVCnzVpmFpVSnNFCmnmzwRFDWDdMllDccMdwDMjWjWlWjg
BJbPJGGGHPZqZQbpMlWWMWlBljjjgDjh
tGQPpZtfTPpqrHsVLSzmRNLtSFsN
WCDlBWWlvMFWlQWpmSZdZnNmGfJZFZ
LqjTjgtjPcHTTJgLThztcLTLnHnmdSpZdpdffnmZSppfGpSn
PtzqzjtqJgggzhqqccqhrQMsMvMwrCwMlBvMwvvsvs
NMsJfsHTMVbjnLnVsC
htWllhmZcWDWBwhZPcmpVRjnVMRLCCjLFpCwRb
PmZMrBtcPmZWhzDWBtMmJQdddHfQGNSqHqQGGTgr
NmfnnsPlHnGqnlsNNmRPltRLvrhvrSGJSJjvFFFSSFJLhb
PzQZccVPVwgPjrJSJjhFFpQr
TdwBgdTVwzdwzlmNfRqPmqqTql
BVLLBPmPmWBlMlLJnJlBlFQVgdRDdRZRZHpZjQzdRdZQdzQZ
trGTsfbTTgHZptzSZW
fsfTNcCqqNhhVhVFVhVBWLLB
LJwgJNfbCvwCJCwBCCNhhHmGHWWSMWmWmbMmTmmGdS
lzRnnltsstZzzRTfHtHWHGWftfHW
ZFFzVFqzqlFcZscZpRZsNphjhjvjfgJhQgQvwvhC
HHzcFNcHFjhjZjlrghLL
pMZJptpZWCmpttRMCWnnDnBGGDLhlLQrhl
MJsMCTZTTpTJRmMCJzfNsNcfNHqzvvfcww
ZDtllsDlVsrQBqQqRfWl
wvJgpPhhscgvpJFNrRjRrWRjqrRjdjRv
zpsNzCsNCJCCPPHSLzznMnDSLGLM
rfrJjFWrwjpnJjjjfrjJJnFVTgTggRWRRRPPLQgCgQcPPT
sSNbSvqmsSZDZZBtNTTPGgMLMRVcgPCMRb
zZDZzNNSmrfpjFCjzj
dbbNJPBbbrFqNqttqrGbqDcmDQRmFmwcwSnQSDcpwS
ZMMTsHjzLlLcnSVwpRRQ
hZTWjWvTZzTTWhszfwbJhrgJqtBbJGdqNPqt
rrqgHrgtcHJRRjWZlRvnnWBn
QbhVmdFppwbdjnMvlnBwMWZP
TpFDdVTFTDfhHfJcSJSzGZGf
sqNTNZHsHjjFBBwJMMNMcCJD
WGLQPjfWfQWPWmtLSRRRLwBJDbtCCJJCbbwCMBbMBc
RnPdLQfPLRdndGGRvfjlgdrTTgTsrgTrZFzF
BfHbjVVqSBFfMSlCLCDrGSQssvlr
tTpnnzpcPnwzhcnJTDtTPRprGlRGGGCWlQsWvrlvrQGQrC
DPwhghDTpPVHqqdgZbZq
ZzPqfGPtRtqfqPbqfGgGZbrhMjmjBCpHpHNCmHtHjmBHnj
QJwllvFWwDvnwCBBzjwwpC
ccJLVQzWFJvVJlVbgrZZLZLRRPSgdr
rBGbLbnTfnZrQbTnHldqsMmHsqlsWfMd
JcJjCCPzPtjCNHdlGGMlll
jjgpRRvcGbwpThVppT
ttDfjtqfjtpTWWwfTbtlWccNGRSZNGPGhZGhGhcwRh
LbCrHdvzLSSHmSRNmc
JCsBvrvBLzFQbbvlVVnpQpDtWlDqfq
vvdvJBfvdTvRBflBJPNmmffmgPCMwDgsss
rFjqLnMcnqrrtMLtjNgCPCsNzzgsPCGFNs
VqLqnLVZqjMZqWnrVtWlZJJSvHvBdRSvBdRvvJ
zZBDzgQQZLlcglzjrCrCMFjGZbMsHm
PnnJVRfttTtwVnnVFGHVsjCFCjrsMM
wPRpRpRnNTpPNlBdQQDdgDNMhN
bNQpFpnwgtDHpbnhWtffmfmhvhhfsZ
LcdLdwCLPPSVSqqwZGhWdJhGJZhlGlsm
TBwSLPSPVRSVqSVqVrcnpMDDngMgnQpbRQFDNH
vPSvBJZSSdJgpJJZBDGDGrdqGdllGrGDrh
HMtsltFlRVVFtlscRjjMcsWwWChWmrnwDWGwChmjGCWq
MQHNlTVHNVHpbbpbTvvBvf
VsbPMwhbWhzdpzNNggnBcTBWNngQ
RmtZZFZqSjqVHmGQNcBHNLGLGHQH
JjRClqCjZlDZmqSqljFZZqRCvsvPfshhMdwsDwbVwzMzhffb
bfGtRgfDtVmsMzTbmz
LjGZwQLLdjFdHLNMhmzBzMNHNmzN
wjQLCFvnnQGdZLGWSjdqWDfPlrRpqRDDRqrpPr
pqnBZqjCNCqQqmllpHGMGdTfML
PsFgrRvSPsWTwWWQwGHLHW
SrvgsFbrrPJJFsrFPtFSCChBDQjqCqtNhDqhCqNC
RJZRWZWMWZPZffRCPWMdRdfQQQjJzHQsssjrSQFVschVHr
NgpnDgvGTNTVFHFFjVFF
jntvgljpGvlnbLtLbBvnLRPlCCwwCfRqMCCqqqddqw
PFBMVDSVPHMTThtMtSBMMVNbQprHbNRgNRRgLnvpnjnN
scGcrcwlswdGlcqvbQgnnpQnqLjnpp
ffwswWzcmlcWWsmcZhrDFrZMFZBMFzhM
LMdZGqdRSSZmCZMRfQjnggvlvggRcznz
tjjFhBrtpthpslcvvlcQzFnFvQ
jrhbjtpJtbZqCLdWLq
HBGBfBttZzbGbljPdpFddFqRmqRzRN
JDWghDDSDqmmDDpc
CLvgMvChCvLphCTSShhMhQsBbfTfsGsrBfjfrljrZZff
RgHgDqDzqQqgcdHqcZGTNlGffGBDGZBTGZ
LFLPWsmvrbwhwwswrTlTTCBNGFfGlNJZNS
vhrLnvhNmWvMsrvwqMdRcptQtztcjptz
sLMLsThhjgqLlsnsLgTLtMFcRbcPcJSwJbbSbtSWScSt
fvrjjDjvNprdPwwJCCSrWPFP
vfZdGzVzfvGGVGpBjnnMglTsgZlqsMlM
TCVMfCfBnHHfLLPFWb
GgQlGJzNzbzHcHHLlcPLHL
tQbNQGgRZZCVtVMZ
QFFMzwjwngsvsBjGGJWbBbBWbB
QdmVDmVDWRPWVPVV
QHtHSdDpLQCCSHrtqrdrttDfLgvnFvFghNszzwgngFwsNF
RzzTNpSRBzSBVpSRlHNSHBSSGPcLNGtjhPPcbcGhPPhcrnct
CCmmCwwdfFJqDmdwsddhsmvdcMbLfcftttbPnjMPbcjPMPbP
mdZQmvssFdqsFZvsZQmvDvmWzgQBWTRzTzHlppWRglHBQh
VWmnfQWzWWnHWMfmmMVNMfWjtBtBNSNSrlStlpjJBBlgBS
cZZvbwsZsbbZvvscCRdFTTTQrBStdBJgSdhjgBjBjJjpJJ
wCFTCbZbFwwCTvFTwsPGccMzMDWVWfzLGmqHnnDHGLQL
sNQQHbbhdlpdrQllqpsqSpGjZDZGgDnVcnjjnnDZ
WWRLGFvJBJPvzzWjnTncDVZTTPgDff
FLRLGRFRJLBWJmJzMRLCvldrMrbbltdhQQlNqtMbsb
HZllwlZSlSZwhvmQjcZhTqcT
sPzzdgpszpzsBdvvMccvcqPThjhM
JDdsDspLzsdzBgVdBGBzCLlwbbwWSnlnnWffHwJcNlHw
nzCTCnpqJqfCnvvjZjWjPcZrmcmZfW
GNdwgVjwRdRglMrPWLPWZWcNWW
dVblgtRwQgSGVBldbQBbBRJnQJTsJHTqnzzJFpjvHnnn
dqpQQrdqQpLfqcGSdggQdgRMmwHBMMBVNRNDFFBDBgNt
vTzsnZCnlCnshbPlvZJbBzVmmVRDNwtHFBwMDVBR
lJCshjTJbVqfVdjjjG
WlLCJlHLcZcJWcWZJnLHnPqlFtSthTnFNThVtNhVhvNVzVtF
QfbgRsspfDRsgfjqqRRpDbSNSTFzBbTbhttVBhVNBzzT
fwgfRdpdfQDqgPHHZJZCcdGddH
sbrbmVmfddzJntZZtwtMMf
PvhwPRlvvWhFvSRhpFMMJGMFppnBTBGJ
RPlCCLDPDClwHbrdzsdNLzgs
HZgqtgbqRZvzwzCh
BFqmGfrNLQfhzJWBhRJwJR
LFqFQjrcrcqFNMmMdHggntDPMnsDbn
NmWmPblGnnTTNlFGPmNWfwdchdlHdBdwcfCfZppZ
rzqzRjgVrJrzzcFdqdCBFBhZhH
VDRsRMjRJJrQsJPTGFNvsbnsnLGm
nrbrBLTffjNRzGQSJHJQGT
tcZqMcppCmHRQPGGCG
pMDcZhpgcpFDfrwNDDrLVjGj
LWlmlmWqvrBMWWBlmjLThBrfPJZfZZCwPCJJwPCTcggCsd
pSbRHbzpHDVFRQRfPdfnZswgcJcppp
SzRNGbzSWNPLWqLv
vqslblpspsvqBFSqcrrZZDdTfFPHccrf
GWRhWmjwhRcQdCDrPjDP
mcWLVnnWJgGRzVSsVSpSSptNpMvb
wHTPfdTvHlPHGpdvvTddGfcJLLWWwWWcCWrqrVMWCVLL
zhsSNZhnshNSnvZmvsCWWSLrVMcrSCLWJcrq
snDnshmNsjnTdHPfDGvdDT
CfrnFFMnnsRNrNCwFCrdssgqgqvVZvZqlTWBNWZqlJBW
htDhDLhwPWWBqTghgB
DPLPzHDtSPStjLGLtzSMwbdMdnCHrRdCFsmfnR
nBNWCvJmVPNnCPNDJWbtmSwqTttcQsSqtqTjQQ
pMflzLlffRRMRdFlflpLddGdsTjwHqzcvwTqtsStQQjtwwsQ
ZhGlphlpvvLLfFGvMLhfrfWNJNNPVPbnPhnDgDbDDNbJ
ZCpCmVlZvlpBBwvvMCrJhrfhMfjjWMSG
qhstFzFFqzHGzNfSMJSGzM
QnHRPRgRQPtPhtnDsqsbDQPBlTcpBwmVmTvbwdwBTVZVpl
PHmqHdddqBWMmTvMvTGMBWPdwhssnnHlhgsNwhwNHQzwrswh
cSbVcDLtbfLSFzhlhJswgtrsww
bSLlFLFFLDZVLpZVjFLdPMdBBqGGPmmqWGdGjM
FQCnQwFRbnrSfgQgwFRCnswmPLpMppPdMMllpLMptMLldPSZ
cJhhJcJVBJjhfHDvJqThvVDcpdGGqdZGdlltpqWdMqpdGWtG
HhzTjJBzJTvNJHvzvvNBzBFnFCNCbCwrbnRbgRwfwQsg
jRzDgbDDQDgVqqDGsjttNdwqNJZNwNdTWrpB
MHvvvlSHFllMhhMrpWBJtlWdpJrTwZ
mFcFFHmCmtcvfvFFHHLDGnRVzjDgnmgmnzGgGg
JJhDpDdmsJJdgmhrpPjGjFLPPSNpjL
WbznbRGnPfrfRSrN
WqGnnVGVMGHtWTCgJvZHggBggZCg
wlrPQtZQvwrzlvNfZLMZBjbbqjqLbSBjTg
PGJDVdsdhsPVPjbTcLcGLgjqbM
VPDRHWRdsRQvpfmmlw
pvTZTSpTZvGGphNvvbDpdrMqrjlWdPqqjWdldNrd
gmmJmsQfJgcRQJQJJncVQjMWllSnqljqBlPPjPHHHH
QVJQRVcwmJcchwpSZLwGbSZZ
zjrDMWcjDzQjDlWrnqqRBRNhBJRBhBJqnf
TTGPPdgGLwdHGwGPTgLbbvhHtRRNRRSfchqRvSqHRJ
TZTccPpdZwPQjllsspjVzD
jHLHhHFRjhcblDRRWbWTdtppLTntTnMmGLMvTp
BBQBgBBCrrgqJqTtMZMpngdtpvpG
QJJJQrsVsQQfQVPCNqsNSjHdhhdRHDNHFHFclh
RbCLnvdtnLRLRbmLPpHdQCvmNJpJSZSJlgDzglGlzcclcDGD
qBBwMjfsFMjsMbfWbwjlzDZlcWclJczgNDGNDl
wqjhrwwhhCvbQPrRnC
vpWDDDWZQQNGllwHlwWVGj
LCPdqdcdtsvdsCtsddvmVrVjjrBwHlmswmBnmw
fLfvSgvMfdCPqzZNThfNNpTJJQ
CVVVLbNVmGNQbGbGHHbHbvdwgQlwJDTFgJQdDZDJFD
ssWBsBWrjSzWrPtBjnSCTwvFZlDjwZDdgwTDwggv
nntPBqBrPsBfnCRCBWzCVcGVHMLNcbHLNmHqGphp
sbbwwzdsbqQQbQnnNbPNGbznHHRdLTggMVHFVvRZTRVRHMZF
mWffDWfflBpfmcWjWrrJVvgRLlMZVVhMFFTlHhMM
rJJCctmjcfvzsqsqbtbqPP
HGWjHWzVctQVcJVtjvRsvLTddqDDDsjRLg
bbMnlNChZQLZhdDs
SMMMMMMNmMllSlrmCczGcVzBcGWFBQGcrt
VwQlqcLfdLGqdqDjjgZrjZBdttjd
zSPPPJzJGjJjZrCBDt
WMTMsTWsccsvGGwH
hZvbQrjTTZjZcjWNrjnQrcTRpGMqcRfRRGzHfHfpfRMqRz
mDJlFmwCVVwbCVbPBRLMMLpRLwRLHqpR
gsCmgJsPDCtCVlvbhgQjhgQbnQbd
fSgbhhGPGJGhRDmlhhHcHDBH
LsMwQWFswsQMsQMvjslcBcDldBTWfDcHRRdl
ZpVFwLQwVLQvCVsMjrJbbCNPbzSJtPbPPf
VDzWMCpfCcCRDzqDzqNnvLZnfntHQnPPLQlt
sJmdbTBdmmGhFhhbJNNQlJnQlQLHPZNn
sdwmwsdrmMRpDRMLcw
JpWmSWpCnCbJBZHZVldbdfZf
rgdrgNdrjgNPrMjwTssrPdfDZqsVfQHDFlQDDHQVsZfB
TRPdNNLgjNwrRTrJpppzCmzmCLSnvS
QbtQJHQmbmfmBRvbQRzBvldqcFljsGcFdGdvsqqGls
ChCPWhDhWZWJVnZpCNChhVDcMcDdcdgGscjgFjGFlsjjGq
WZNTWNhNZfJJbTJTmR
CHGCHFcZvCrchrZrhsVtsBQjMstfZMMBgg
NNqwDLmDjJgQBmVQ
wdWLLTgWRTWcCcbrHCHhGW
bTZZvNjNjLgTCHcWhccfhWJdhvnc
mnFFmPGSwRPShzVPPWPdhhzr
FRtBFGBMFQFttRwtZgTjCTnQNbNLjTCH
bJSqrSpDJbSNbFjSFCfPWGcwGWPrcTCfwr
tRtLhDsvhQZlHRhRtQQnCnCcdwCPwTwdGcGP
HsHvsmBZvmvsmBhHvLssVqDSNgFMDzgbbDVJzbpMVq
nSSDHRRRQRBCLCQC
qGmfPzGmGlrrrpfrqlzrJtLvBlhQbSCvbtCtlFhLFC
zzpmqqJJVVfJfPfMpfdHNndsNwDSMSDDNcsc
CscQsVMhCsMsMHhhVthtwmgZNRqzWLBRLRLmBWmZWBND
JQJdddrjrLqBgDBq
QbFlTffpMbMnsPCh
gDdbVbVDddDfVfWQfBRLQZsZLRQQ
FCCTrGCMStwGHTtTWLQhLZrlRssRhRhp
FSHqtFTmFwmCsSwGTHtMTSdjjcdnVddgzmbVmjmndbbD
JtBBMcLWLdfFLhMttcWWhfWLrTRGFsbwTmRGwmwbbCTGGsbD
PzQpSQQQvzVvpzHqjvNvQSvGRmmTDVRDmsGsRGsrcDcDGC
cQPHSPvPvZHqcZjzpZjnZNtWlLdtldJWfnfhlJJtLdMg
nPPssTBnMJPdtHPVHtRhpv
bSSgGFWDgWwDFFlmWlcShqdpRqpVcHvvnqpvpRHd
bGFnGljgSsjBCTBszz";

        }

    }

}